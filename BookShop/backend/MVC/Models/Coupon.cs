using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
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

    #region Coupon type Enum

    /// <summary>
    /// Coupon type
    /// </summary>
    [Display(Name = "Coupon Type")]
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
    [Display(Name = "Minimum Amount")]
    public double MinimumAmount { get; set; }

    /// <summary>
    /// Picture
    /// </summary>
    public byte[] Picture { get; set; }

    /// <summary>
    /// Active status
    /// </summary>
    [Display(Name = "Is Active")]
    public bool IsActive { get; set; }
  }
}
