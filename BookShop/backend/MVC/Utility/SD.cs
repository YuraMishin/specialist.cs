namespace MVC.Utility
{
  /// <summary>
  /// Class contains project's constants
  /// </summary>
  public static class SD
  {
    /// <summary>
    /// Default Food Image
    /// </summary>
    public const string DefaultBookImage = "default_book.png";

    /// <summary>
    /// Admin email
    /// </summary>
    public const string AdminEmail = "admin@mail.ru";

    /// <summary>
    /// User email
    /// </summary>
    public const string UserEmail = "user@mail.ru";

    /// <summary>
    /// Manager user
    /// </summary>
    public const string ManagerUser = "Manager";

    /// <summary>
    /// FrontDesk user
    /// </summary>
    public const string FrontDeskUser = "FrontDesk";

    /// <summary>
    /// CustomerEnd user
    /// </summary>
    public const string CustomerEndUser = "Customer";

    /// <summary>
    /// Shopping cart count
    /// </summary>
    public const string ssShoppingCartCount = "ssCartCount";

    /// <summary>
    /// Method convert string to raw html
    /// </summary>
    /// <param name="source">String</param>
    /// <returns>String</returns>
    public static string ConvertToRawHtml(string source)
    {
      char[] array = new char[source.Length];
      int arrayIndex = 0;
      bool inside = false;

      for (int i = 0; i < source.Length; i++)
      {
        char let = source[i];
        if (let == '<')
        {
          inside = true;
          continue;
        }

        if (let == '>')
        {
          inside = false;
          continue;
        }

        if (!inside)
        {
          array[arrayIndex] = let;
          arrayIndex++;
        }
      }

      return new string(array, 0, arrayIndex);
    }
  }
}
