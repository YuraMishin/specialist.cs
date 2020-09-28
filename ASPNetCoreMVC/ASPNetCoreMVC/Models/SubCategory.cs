using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNetCoreMVC.Models
{
  /// <summary>
  /// Class implements SubCategory Entity
  /// </summary>
  [Table("SubCategories")]
  public class SubCategory
  {
    /// <summary>
    /// Id
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [Display(Name = "SubCategory Name")]
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    #region FKCategory

    /// <summary>
    /// Category Id
    /// </summary>
    [Required]
    [Display(Name = "Category")]
    public int CategoryId { get; set; }

    /// <summary>
    /// Foreign key to Category Entity
    /// </summary>
    [ForeignKey("CategoryId")]
    public virtual Category Category { get; set; }

    #endregion
  }
}
