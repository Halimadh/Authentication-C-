using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApp.Models.BLL;
using WebApp.Models.Entities;

namespace WebApp
{
    public class JwtAuthenticationService : IJwtAuthenticationService
    {
        public Labo Authenticate(string email, string password)
        {
            return BLL_labo.GetUser(email, password);
        }

        public string GenerateToken(string secret, List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims), // les informations du client connecté dans le token
                Expires = DateTime.UtcNow.AddMinutes(1), // duree de validiter du token
                SigningCredentials = new SigningCredentials(
                    key,
                    SecurityAlgorithms.HmacSha256Signature)

            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public int RegisterLabo(Labo labo)
        {
            return BLL_labo.Add(labo);
        }

        public Labo LaboExist(string email)
        {
            return BLL_labo.GetUserByEmail(email);
        }
    }
}
