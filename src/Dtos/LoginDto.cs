using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerAPI.Dtos;


public record LoginDto(
    [Required] string Username, 
    [Required] string Password
);