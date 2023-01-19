using System.Security.Claims;
using WebApp.Models.Entities;

namespace WebApp
{
    public interface IJwtAuthenticationService
    {
        Labo Authenticate(string email, string password);
        string GenerateToken(string secret, List<Claim> claims);
        int RegisterLabo(Labo labo);

        Labo LaboExist(string email);
    }
}
