using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crud.Models;

public partial class Product
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductId { get; set; }
    [Required]
    public string ProductName { get; set; }
    [Required]
    public string CategoryName { get; set; }
    [Required]
    public string Manufacturer { get; set; }
    [Required]
    public int Price { get; set; }
}

