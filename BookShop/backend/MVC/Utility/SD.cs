using System;
using MVC.Models;

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
    /// CouponCode
    /// </summary>
    public const string ssCouponCode = "ssCouponCode";

    /// <summary>
    /// Method converts string to raw html
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

    /// <summary>
    /// Method calculates discounted price
    /// </summary>
    /// <param name="couponFromDb">Coupon from Db</param>
    /// <param name="originalOrderTotal">Original Order Total</param>
    /// <returns>double</returns>
    public static double DiscountedPrice(Coupon couponFromDb,
      double originalOrderTotal)
    {
      if (couponFromDb == null)
      {
        return originalOrderTotal;
      }
      else
      {
        if (couponFromDb.MinimumAmount > originalOrderTotal)
        {
          return originalOrderTotal;
        }
        else
        {
          //everything is valid
          if (Convert.ToInt32(couponFromDb.CouponType) ==
              (int) Coupon.ECouponType.Dollar)
          {
            //$10 off $100
            return Math.Round(originalOrderTotal - couponFromDb.Discount, 2);
          }

          if (Convert.ToInt32(couponFromDb.CouponType) ==
              (int) Coupon.ECouponType.Percent)
          {
            //10% off $100
            return Math.Round(
              originalOrderTotal -
              (originalOrderTotal * couponFromDb.Discount / 100), 2);
          }
        }
      }

      return originalOrderTotal;
    }
  }
}
