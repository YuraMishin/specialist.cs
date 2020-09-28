using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNetCoreMVC.Models
{
  /// <summary>
  /// Class implements MenuItem entity
  /// </summary>
  [Table("MenuItems")]
  public class MenuItem
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

    /// <summary>
    /// Description
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Description { get; set; }

    #region Spicyness

    /// <summary>
    /// Spicyness
    /// </summary>
    public string Spicyness { get; set; }

    /// <summary>
    /// Enum
    /// </summary>
    public enum ESpicy
    {
      NA = 0,
      NotSpicy = 1,
      Spicy = 2,
      VerySpicy = 3
    }

    #endregion

    /// <summary>
    /// Image
    /// </summary>
    public string Image { get; set; }

    #region Category

    /// <summary>
    /// CategoryId
    /// </summary>
    [Display(Name = "Category")]
    public int CategoryId { get; set; }

    /// <summary>
    /// Category
    /// </summary>
    [ForeignKey("CategoryId")]
    public virtual Category Category { get; set; }

    #endregion

    #region SubCategory

    /// <summary>
    /// SubCategoryId
    /// </summary>
    [Display(Name = "SubCategory")]
    public int SubCategoryId { get; set; }

    /// <summary>
    /// SubCategory
    /// </summary>
    [ForeignKey("SubCategoryId")]
    public virtual SubCategory SubCategory { get; set; }

    #endregion

    /// <summary>
    /// Price
    /// </summary>
    [Range(1, Int32.MaxValue, ErrorMessage = "Price should be greater than $1")]
    public double Price { get; set; }
  }
}
