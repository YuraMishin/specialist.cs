using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
  /// <summary>
  /// Class implements OrderDetails Entity
  /// </summary>
  [Table("OrderDetails")]
  public class OrderDetails
  {
    /// <summary>
    /// Id
    /// </summary>
    [Key]
    public int Id { get; set; }

    #region FK_OrderId

    /// <summary>
    /// OrderId
    /// </summary>
    [Required]
    public int OrderId { get; set; }

    /// <summary>
    /// Foreign key to OrderHeader Entity
    /// </summary>
    [ForeignKey("OrderId")]
    public virtual OrderHeader OrderHeader { get; set; }

    #endregion

    #region FK_BookId

    /// <summary>
    /// BookId
    /// </summary>
    [Required]
    public int BookId { get; set; }

    /// <summary>
    /// Foreign key to Book Entity
    /// </summary>
    [ForeignKey("BookId")]
    public virtual Book Book { get; set; }

    #endregion

    /// <summary>
    /// Count
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Price
    /// </summary>
    [Required]
    public double Price { get; set; }
  }
}
