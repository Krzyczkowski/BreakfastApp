using BuberBreakfast.Common.Interfaces.Authentication;
using BuberBreakfast.Contracts.Authentication;
using BuberBreakfast.Services.Authentication;

public class AuthenticationService : IAuthenticationService{

    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator){
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    
    public AuthenticationResult Login(LoginRequest loginRequest){
        return new AuthenticationResult(
            Guid.NewGuid(),
            "wiktor",
            "krzyczkowski",
            loginRequest.Email,
            "token"
        );
    }
    public AuthenticationResult Register(RegisterRequest registerRequest){

        //chceck if user exists
        //create user, generate unique id
        

        Guid userId = Guid.NewGuid();
        // generate JWT token
        var token = _jwtTokenGenerator.GenerateToken(userId,registerRequest.FirstName,registerRequest.LastName);

        return new AuthenticationResult(
            userId,
            registerRequest.FirstName,
            registerRequest.LastName,
            registerRequest.Email,
            token
        );
    }
}