using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFPostgrsql.App.Core.Models
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
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
    /// Name
    /// </summary>
    [Column("Name", TypeName = "varchar")]
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    /// <summary>
    /// Description
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Description { get; set; }

    /// <summary>
    /// Book Age
    /// </summary>
    public BookAge BookAge { get; set; }

    /// <summary>
    /// Full Price
    /// </summary>
    [Range(1, Int32.MaxValue, ErrorMessage = "Price should be greater than $1")]
    public double FullPrice { get; set; }

    /// <summary>
    /// Link to Authors table.
    /// Many-to-One
    /// </summary>
    public Author Author { get; set; }

    /// <summary>
    /// Link to Tags table.
    /// Many-to-Many
    /// </summary>
    public IList<Tag> Tags { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    public Book()
    {
      Tags = new List<Tag>();
    }
  }
}
