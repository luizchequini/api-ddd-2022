using System.IdentityModel.Tokens.Jwt;

namespace WebAPIs.Token;

public class TokenJWT
{
    private readonly JwtSecurityToken Token;

    internal TokenJWT(JwtSecurityToken token)
    {
        this.Token = token;
    }

    public DateTime ValidTo => Token.ValidTo;
    public string value => new JwtSecurityTokenHandler().WriteToken(this.Token);
}
