using BuberBreakfast.Models;

namespace BuberBreakfast.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator{
    string GenerateToken(User user);
}