using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNetCoreMVC.Models
{
  /// <summary>
  /// Class implements Category Entity
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
    /// Name
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
  }
}
