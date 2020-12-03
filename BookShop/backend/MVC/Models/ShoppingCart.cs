using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
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

    #region FK_ApplicationUserId One-to-One

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

    #region FK_BookId Many-to-Many

    /// <summary>
    /// BookId
    /// </summary>
    public int BookId { get; set; }

    /// <summary>
    /// Foreign key to Book Entity
    /// </summary>
    [NotMapped]
    [ForeignKey("BookIdId")]
    public virtual Book Book { get; set; }

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
