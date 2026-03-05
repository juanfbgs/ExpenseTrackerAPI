using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerAPI.Dtos;

public record RegisterDto(
   [Required][MinLength(2), MaxLength(50)] string Username,
   [Required][MinLength(6)] string Password,
   [Required][EmailAddress] string Email
);