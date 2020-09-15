namespace SQLtree
{
  public static class Database
  {
    /// <summary>
    /// Имя базы данных
    /// </summary>
    public const string Name = "TcAppleTest";

    /// <summary>
    /// Процедура получения корневых узлов
    /// </summary>
    public const string GetRootNodes = "GetRootNodes";

    /// <summary>
    /// Процедура получения дочерних узлов
    /// </summary>
    public const string GetChildNodes = "GetChildNodes";

    /// <summary>
    /// Процедура редактирования узла
    /// </summary>
    public const string EditNode = "EditNode";

    /// <summary>
    /// Процедура добавления узла
    /// </summary>
    public const string AddNode = "AddNode";

    /// <summary>
    /// Процедура удаления узла
    /// </summary>
    public const string DelNode = "DelNode";
  }
}