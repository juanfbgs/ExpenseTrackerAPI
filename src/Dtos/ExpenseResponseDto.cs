namespace ExpenseTrackerAPI.Dtos;

public record ExpenseResponseDto(
    int Id,
    string Description,
    decimal Amount,
    string Category,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    int UserId);