using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNetCore.Models
{
  /// <summary>
  /// Class implements the Book entity
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
    [StringLength(255)]
    public string Name { get; set; }
  }
}
