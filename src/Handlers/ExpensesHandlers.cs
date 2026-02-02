using ExpenseTrackerAPI.Data;
using ExpenseTrackerAPI.Dtos;
using ExpenseTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ExpenseTrackerAPI.Handlers;

public static class ExpensesHandlers
{
    public static async Task<IResult> GetExpenses(AppDbContext context, ClaimsPrincipal principal)
    {
        var userId = GetUserId(principal);
        var expenses = await context.Expenses
            .Where(e => e.UserId == userId)
            .Select(e => new ExpenseResponseDto(e.Id, e.Description, e.Amount, e.Category, e.CreatedAt, e.UserId))
            .ToListAsync();

        return Results.Ok(expenses);
    }

    public static async Task<IResult> GetExpenseById(int id, AppDbContext context, ClaimsPrincipal principal)
    {
        var userId = GetUserId(principal);
        var expense = await context.Expenses.FirstOrDefaultAsync(e => e.Id == id && e.UserId == userId);

        if (expense is null) return Results.NotFound();

        return Results.Ok(new ExpenseResponseDto(expense.Id, expense.Description, expense.Amount, expense.Category, expense.CreatedAt, expense.UserId));
    }

    public static async Task<IResult> CreateExpense(ExpenseCreateDto expenseCreateDto, AppDbContext context, ClaimsPrincipal principal)
    {
        var userId = GetUserId(principal);
        
        var expense = new Expense
        {
            Description = expenseCreateDto.Description,
            Amount = expenseCreateDto.Amount,
            Category = expenseCreateDto.Category,
            CreatedAt = expenseCreateDto.CreatedAt,
            UserId = userId
        };

        context.Expenses.Add(expense);
        await context.SaveChangesAsync();

        var response = new ExpenseResponseDto(expense.Id, expense.Description, expense.Amount, expense.Category, expense.CreatedAt, expense.UserId);
        return Results.CreatedAtRoute("GetExpenseById", new { id = expense.Id }, response);
    }

    public static async Task<IResult> DeleteExpense(int id, AppDbContext context, ClaimsPrincipal principal)
    {
        var userId = GetUserId(principal);
        var expense = await context.Expenses.FirstOrDefaultAsync(e => e.Id == id && e.UserId == userId);

        if (expense is null) return Results.NotFound();

        context.Expenses.Remove(expense);
        await context.SaveChangesAsync();
        return Results.NoContent();
    }

    // Helper to extract the User ID from the JWT NameIdentifier claim
    private static int GetUserId(ClaimsPrincipal principal) =>
        int.Parse(principal.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
}