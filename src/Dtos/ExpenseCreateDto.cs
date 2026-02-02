namespace ExpenseTrackerAPI.Dtos;

public record ExpenseCreateDto(
    string Description,
    decimal Amount,
    string Category,
    DateTime CreatedAt);