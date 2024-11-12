namespace BuberBreakfast.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator{
    string GenerateToken(Guid userId, string FirstName, string LastName);
}