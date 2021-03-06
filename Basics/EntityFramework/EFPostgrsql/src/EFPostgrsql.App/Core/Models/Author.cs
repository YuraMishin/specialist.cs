using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFPostgrsql.App.Core.Models
{
  /// <summary>
  /// Class Author.
  /// Class implements Author entity
  /// </summary>
  [Table("Authors")]
  public class Author
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
    /// Name
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    /// <summary>
    /// Link to Books table.
    /// One-to-Many
    /// </summary>
    public IList<Book> Books { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    public Author()
    {
      Books = new List<Book>();
    }
  }
}
