using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFPostgrsql.App.Models
{
  /// <summary>
  /// Class Category.
  /// Class implements Category entity
  /// </summary>
  [Table("Categories")]
  public class Category
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
  }
}
