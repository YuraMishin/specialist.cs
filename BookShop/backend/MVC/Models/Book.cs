using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
  /// <summary>
  /// Class implements Book entity
  /// </summary>
  [Table("Books")]
  public class Book
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

    #region Age

    /// <summary>
    /// Age
    /// </summary>
    public string Age { get; set; }

    /// <summary>
    /// Enum
    /// </summary>
    public enum EAge
    {
      Child = 0,
      Adult = 1
    }

    #endregion

    /// <summary>
    /// Image
    /// </summary>
    public string Image { get; set; }

    #region FK_Category Many-to-One

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

    #region FK_SubCategory Many-to-One

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
