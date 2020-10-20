using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNetCoreMVC.Models
{
  /// <summary>
  /// Class implements ShoppingCart Entity
  /// </summary>
  [Table("ShoppingCarts")]
  public class ShoppingCart
  {
    /// <summary>
    /// Id
    /// </summary>
    [Key]
    public int Id { get; set; }

    #region FK_ApplicationUserId

    /// <summary>
    /// ApplicationUserId
    /// </summary>
    public string ApplicationUserId { get; set; }

    /// <summary>
    /// Foreign key to ApplicationUser Entity
    /// </summary>
    [NotMapped]
    [ForeignKey("ApplicationUserId")]
    public virtual ApplicationUser ApplicationUser { get; set; }

    #endregion

    #region FK_MenuItemId

    /// <summary>
    /// MenuItemId
    /// </summary>
    public int MenuItemId { get; set; }

    /// <summary>
    /// Foreign key to MenuItem Entity
    /// </summary>
    [NotMapped]
    [ForeignKey("MenuItemId")]
    public virtual MenuItem MenuItem { get; set; }

    #endregion

    /// <summary>
    /// Count
    /// </summary>
    [Range(1, int.MaxValue,
      ErrorMessage = "Please enter a value greater than or equal to {1}")]
    public int Count { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    public ShoppingCart()
    {
      Count = 1;
    }
  }
}
