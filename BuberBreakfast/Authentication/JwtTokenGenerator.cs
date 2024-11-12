using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BuberBreakfast.Authentication;
using BuberBreakfast.Common.Interfaces.Authentication;
using BuberBreakfast.Contracts.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

public class JwtTokenGenerator : IJwtTokenGenerator{

    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IOptions<JwtSettings> jwtSettings){
        _jwtSettings = jwtSettings.Value;
    }
    public string GenerateToken(Guid userId, string FirstName, string LastName){
        var sigCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256);

        var claims = new[]{
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, LastName),
        };

        var securityToken = new JwtSecurityToken(
            issuer:_jwtSettings.Issuer,
            expires: DateTime.Now.AddMinutes(_jwtSettings.ExpirationTimeInMinutes),
            claims:claims,
            signingCredentials:sigCredentials
            );
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}