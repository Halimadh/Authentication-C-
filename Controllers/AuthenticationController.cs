using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApp.Models.Entities;

namespace WebApp.Controllers
{
    [Route("[controller]")]
    [Route("/")]
    public class AuthenticationController : Controller
    {
        private readonly IJwtAuthenticationService _jwtAuthenticationService;
        private readonly IConfiguration _config;

        [Route("/login")]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        public AuthenticationController(IJwtAuthenticationService JwtAuthenticationService, IConfiguration config)
        {
            _jwtAuthenticationService = JwtAuthenticationService;
            _config = config;
        }


        [HttpPost]
        [Route("/login")]
        public IActionResult Login( LoginModel model)
        {
            var labo = _jwtAuthenticationService.Authenticate(model.Email, model.Password);
            if (labo != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, labo.Name),
                    new Claim(ClaimTypes.Email, labo.Email),
                };
                var token = _jwtAuthenticationService.GenerateToken(_config["Jwt:Key"], claims);


                HttpContext.Session.SetString("Token", token);
                return RedirectToAction("index", "home") ;
            }
            return Unauthorized();
        }

    }

}
