using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFPostgrsql.App.Models
{
  /// <summary>
  /// Class Book.
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
    /// Created On
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Updated On
    /// </summary>
    public DateTime UpdatedOn { get; set; }

    /// <summary>
    /// Title
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Title { get; set; }

    /// <summary>
    /// Description
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Description { get; set; }

    /// <summary>
    /// Full Price
    /// </summary>
    [Range(1, Int32.MaxValue, ErrorMessage = "Price should be greater than $1")]
    public double FullPrice { get; set; }
  }
}
