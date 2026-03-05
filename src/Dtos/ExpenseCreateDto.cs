using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerAPI.Dtos;

public record ExpenseCreateDto(
    [Required]
    [StringLength(200, MinimumLength = 3, ErrorMessage = "Description must be between 3 and 200 characters.")]
    [RegularExpression(@"[^\s]+.*", ErrorMessage = "Description cannot be only whitespace.")] 
    string Description,
    [Required] [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be a positive value greater than zero.")]
    decimal Amount,
    [Required] 
    [MinLength(1, ErrorMessage = "Category cannot be empty.")]
    [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Category contains invalid characters.")]
    string Category
);