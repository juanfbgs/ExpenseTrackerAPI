namespace ExpenseTrackerAPI.Dtos;

public record RegisterDto(
    string Username, 
    string Password, 
    string Email
);