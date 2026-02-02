using ExpenseTrackerAPI.Handlers;

namespace ExpenseTrackerAPI.Endpoints;

public static class ExpensesEndpoints
{
    public static void MapExpensesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/expenses")
            .WithTags("Expenses")
            .RequireAuthorization();

        group.MapGet("/", ExpensesHandlers.GetExpenses);

        group.MapGet("/{id:int}", ExpensesHandlers.GetExpenseById)
             .WithName("GetExpenseById");

        group.MapPost("/", ExpensesHandlers.CreateExpense);

        group.MapDelete("/{id:int}", ExpensesHandlers.DeleteExpense);
    }
}