namespace Entities.Models;
using System.ComponentModel.DataAnnotations;

public class Product
{
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Product name is required.")]
    public String? ProductName { get; set; } = String.Empty;

    [Required(ErrorMessage = "Price is required.")]
    public decimal Price { get; set; }

}
