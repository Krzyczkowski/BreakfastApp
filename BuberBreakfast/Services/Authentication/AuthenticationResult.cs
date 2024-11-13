using BuberBreakfast.Contracts.Authentication;
using BuberBreakfast.Models;

public record AuthenticationResult(
    User user,
    string Token
);