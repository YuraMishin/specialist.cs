using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
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
    [Display(Name = "Category Name")]
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
  }
}
