namespace MVC.Extensions
{
  /// <summary>
  /// Class allows get property value by name
  /// </summary>
  public static class ReflectionExtension
  {
    /// <summary>
    /// Method implements get property value by name feature
    /// </summary>
    /// <param name="item">Item</param>
    /// <param name="propertyName">Property Name</param>
    /// <typeparam name="T">T</typeparam>
    /// <returns></returns>
    public static string GetPropertyValue<T>(this T item, string propertyName)
    {
      return item.GetType()
        .GetProperty(propertyName)
        .GetValue(item, null)
        .ToString();
    }
  }
}
