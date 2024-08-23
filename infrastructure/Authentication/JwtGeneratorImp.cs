using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Common.interfaces.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BuberDinner.infrastructure.Authentication;

public class JwtGeneratorImp : IJwtGenerator {

    private readonly IDateTimeProvider _IDateTimeProvider;
    private readonly JwtSettings _jwtSettings;
    public JwtGeneratorImp(IDateTimeProvider dateTimeProvider,IOptions<JwtSettings> jwtSettings){
        _IDateTimeProvider=dateTimeProvider;
        _jwtSettings=jwtSettings.Value;
    }
    public string JwtGenerator(Guid id,string FirstName,string LastName){
        
        var signign_credentials=new SigningCredentials(
           new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256);


        var claims=new[]{
            new Claim(JwtRegisteredClaimNames.Sub,id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName,FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName,LastName),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
        };

        var securityToken= new JwtSecurityToken(
            issuer:_jwtSettings.Issuer,
            expires:_IDateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            claims:claims,
            signingCredentials:signign_credentials
            );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}