using ExpenseTrackerAPI.Data;
using ExpenseTrackerAPI.Dtos;
using ExpenseTrackerAPI.Interfaces;
using ExpenseTrackerAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerAPI.Handlers;

public static class AuthHandlers
{
    public static async Task<IResult> Register(
        RegisterDto registerDto,
        AppDbContext context,
        IPasswordHasher<User> hasher)
    {
        if (await context.Users.AnyAsync(u => u.Username == registerDto.Username))
            return Results.Conflict("Username is already taken.");
        
        var user = new User
        {
            Username = registerDto.Username,
            Email = registerDto.Email
        };

        user.PasswordHash = hasher.HashPassword(user, registerDto.Password);

        context.Users.Add(user);
        await context.SaveChangesAsync();

        return Results.Ok(new { message = "User registered successfully" });
    }

    public static async Task<IResult> Login(
        LoginDto loginDto,
        AppDbContext context,
        ITokenService tokenService,
        IPasswordHasher<User> hasher
    )
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Username == loginDto.Username);

        if (user is null) return Results.Unauthorized();

        var result = hasher.VerifyHashedPassword(user, user.PasswordHash, loginDto.Password);

        if (result == PasswordVerificationResult.Failed)
            return Results.Unauthorized();

        var token = tokenService.CreateToken(user);
        return Results.Ok(new { Token = token });
    }
}