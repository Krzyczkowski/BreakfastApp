using BuberBreakfast.Contracts.Authentication;

namespace BuberBreakfast.Services.Authentication;

public interface IAuthenticationService{
    AuthenticationResult Login(LoginRequest loginRequest);
    AuthenticationResult Register(RegisterRequest registerRequest);
}