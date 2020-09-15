USE master
GO
CREATE DATABASE TcAppleTest COLLATE Cyrillic_General_CS_AI
GO
USE TcAppleTest
GO
CREATE TABLE Nodes (
	Phone smallint NOT NULL,
	Name nchar(100) NOT NULL,
  CONSTRAINT PK_Nodes PRIMARY KEY (Phone),
  CONSTRAINT UQ_Name UNIQUE (Name),
  CONSTRAINT PhoneRange CHECK (Phone >=100 AND Phone <= 999)
)
GO
CREATE TABLE NodeRefs (
	ParentPhone smallint NOT NULL,
	Phone smallint NOT NULL,
  CONSTRAINT PK_NodeRefs PRIMARY KEY (
	  ParentPhone,
	  Phone
  ),
  CONSTRAINT FK_ParentPhone FOREIGN KEY (ParentPhone)
    REFERENCES Nodes(Phone)
    ON UPDATE CASCADE
    ON DELETE CASCADE
)
GO
CREATE PROCEDURE EditNode
  @OldPhone smallint,
  @NewPhone smallint,
  @name nchar(100)
AS
BEGIN
  UPDATE Nodes
  SET Phone = @NewPhone, Name = @name
  WHERE Phone = @OldPhone;
END;
GO
CREATE PROCEDURE DelNode
  @phone smallint
AS
  DELETE
  FROM Nodes
  WHERE Phone = @phone;
GO
CREATE PROCEDURE AddNode
	@phone smallint, 
	@name nchar(100),
	@parent smallint = NULL
AS
BEGIN
  BEGIN TRAN
  INSERT INTO Nodes(Phone, Name)
  VALUES (@phone, @name);
  IF @parent IS NOT NULL
    INSERT INTO NodeRefs(ParentPhone, Phone)
    VALUES (@parent, @phone);
  COMMIT TRAN;
END
GO
CREATE PROCEDURE GetRootNodes
AS
BEGIN
  SELECT Phone, Name
  FROM Nodes
  WHERE NOT EXISTS (
    SELECT *
    FROM NodeRefs
    WHERE Phone = Nodes.Phone
  );
END;
GO
CREATE PROCEDURE GetChildNodes
  @parent smallint
AS
BEGIN
  SELECT NodeRefs.Phone, Name
  FROM Nodes INNER JOIN NodeRefs
  ON Nodes.Phone = NodeRefs.Phone
  WHERE ParentPhone = @parent;
END;
GO