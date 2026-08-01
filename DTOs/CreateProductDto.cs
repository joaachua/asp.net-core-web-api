using System.ComponentModel.DataAnnotations;

namespace NmqPracticeApi.DTOs;

public class CreateProductDto
{
    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }

    [Range(0, int.MaxValue)]
    public int Stock { get; set; }
}