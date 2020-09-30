using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNetCoreMVC.Models
{
  /// <summary>
  /// Class implements Coupon Entity
  /// </summary>
  [Table("Coupons")]
  public class Coupon
  {
    /// <summary>
    /// Id
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    #region Coupon

    /// <summary>
    /// Coupon type
    /// </summary>
    [Required]
    public string CouponType { get; set; }

    public enum ECouponType
    {
      Percent = 0,
      Dollar = 1
    }

    #endregion

    /// <summary>
    /// Discount
    /// </summary>
    [Required]
    public double Discount { get; set; }

    /// <summary>
    /// Minimum amount
    /// </summary>
    [Required]
    public double MinimumAmount { get; set; }

    /// <summary>
    /// Picture
    /// </summary>
    public byte[] Picture { get; set; }

    /// <summary>
    /// Active status
    /// </summary>
    public bool isActive { get; set; }
  }
}
