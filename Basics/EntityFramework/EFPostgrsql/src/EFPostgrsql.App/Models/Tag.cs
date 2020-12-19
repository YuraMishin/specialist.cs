using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFPostgrsql.App.Models
{
  /// <summary>
  /// Class Tag.
  /// Class implements Tag entity
  /// </summary>
  [Table("Tags")]
  public class Tag
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
    /// Many-to-Many
    /// </summary>
    public IList<Book> Books { get; set; }
  }
}
