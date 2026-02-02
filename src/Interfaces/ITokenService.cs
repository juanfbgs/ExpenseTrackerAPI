using ExpenseTrackerAPI.Models;

namespace ExpenseTrackerAPI.Interfaces;

public interface ITokenService
{
    string CreateToken(User user);
}