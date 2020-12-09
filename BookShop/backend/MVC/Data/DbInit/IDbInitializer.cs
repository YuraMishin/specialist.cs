namespace MVC.Data.DbInit
{
  /// <summary>
  /// Interface IDbInitializer.
  /// Describes entity to initialize database
  /// </summary>
  public interface IDbInitializer
  {
    /// <summary>
    /// Method initializes database
    /// </summary>
    void Initialize();
  }
}
