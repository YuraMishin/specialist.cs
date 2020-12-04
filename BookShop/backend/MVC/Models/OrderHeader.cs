using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
  /// <summary>
  /// Class implements OrderHeader Entity
  /// </summary>
  [Table("OrderHeaders")]
  public class OrderHeader
  {
    /// <summary>
    /// Id
    /// </summary>
    [Key]
    public int Id { get; set; }

    #region FK_UserId

    /// <summary>
    /// UserId
    /// </summary>
    [Required]
    public string UserId { get; set; }

    /// <summary>
    /// Foreign key to ApplicationUser Entity
    /// </summary>
    [ForeignKey("UserId")]
    public virtual ApplicationUser ApplicationUser { get; set; }

    #endregion

    /// <summary>
    /// Order Date
    /// </summary>
    [Required]
    public DateTime OrderDate { get; set; }

    /// <summary>
    /// Order Total Original
    /// </summary>
    [Required]
    public double OrderTotalOriginal { get; set; }

    /// <summary>
    /// Order Total
    /// </summary>
    [Required]
    [DisplayFormat(DataFormatString = "{0:C}")]
    [Display(Name = "Order Total")]
    public double OrderTotal { get; set; }

    /// <summary>
    /// Pickup Time
    /// </summary>
    [Required]
    [Display(Name = "Pickup Time")]
    public DateTime PickUpTime { get; set; }

    /// <summary>
    /// PickUp Date
    /// </summary>
    [Required]
    [NotMapped]
    public DateTime PickUpDate { get; set; }

    /// <summary>
    /// Coupon Code
    /// </summary>
    [Display(Name = "Coupon Code")]
    public string CouponCode { get; set; }

    /// <summary>
    /// CouponCodeDiscount
    /// </summary>
    public double CouponCodeDiscount { get; set; }

    /// <summary>
    /// Status
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Payment Status
    /// </summary>
    public string PaymentStatus { get; set; }

    /// <summary>
    /// Comments
    /// </summary>
    public string Comments { get; set; }

    /// <summary>
    /// Pickup Name
    /// </summary>
    [Display(Name = "Pickup Name")]
    public string PickupName { get; set; }

    /// <summary>
    /// Phone Number
    /// </summary>
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }

    /// <summary>
    /// TransactionId
    /// </summary>
    public string TransactionId { get; set; }
  }
}
