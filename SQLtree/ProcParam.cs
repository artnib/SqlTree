namespace SQLtree
{
  /// <summary>
  /// Параметры хранимых процедур
  /// </summary>
  public static class ProcParam
  {
    /// <summary>
    /// Имя
    /// </summary>
    public const string Name = "@name";

    /// <summary>
    /// Телефон
    /// </summary>
    public const string Phone = "@phone";

    /// <summary>
    /// Старый телефон
    /// </summary>
    public const string OldPhone = "@OldPhone";

    /// <summary>
    /// Новый телефон
    /// </summary>
    public const string NewPhone = "@NewPhone";

    /// <summary>
    /// Телефон родительского узла
    /// </summary>
    public const string Parent = "@parent";
  }
}