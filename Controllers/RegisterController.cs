using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using WebApp.Models.Entities;

namespace WebApp.Controllers
{
    [Route("[controller]")]
    [Route("/register")]
    public class RegisterController : Controller
    { 
        private readonly IJwtAuthenticationService _jwtAuthenticationService;
        private readonly IConfiguration _config;

    
        [Route("/register")]
        public IActionResult Index()
        {
            return View();
        }
        public RegisterController(IJwtAuthenticationService JwtAuthenticationService, IConfiguration config)
        {
            _jwtAuthenticationService = JwtAuthenticationService;
            _config = config;
        }
        [HttpPost]
        [Route("/register")]
        public IActionResult signUp(Labo labo)
        {
            
            if (ModelState.IsValid)
            {
                var n = _jwtAuthenticationService.RegisterLabo(labo);
                return RedirectToAction("index", "home");
            }

            return Unauthorized();
        }

    }

}
