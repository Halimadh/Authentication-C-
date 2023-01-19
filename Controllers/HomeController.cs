using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("[controller]")]
    //[Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            string token = HttpContext.Session.GetString("Token");
            ViewBag.MessageToken = $"Le token est : {token}";
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                claims.Where(x => x.Type == ClaimTypes.Name)
                        .FirstOrDefault();
                // obtenir une information du token
                var NomUserLogged = claims.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault()?.Value;
                var userRole = claims.Where(x => x.Type == ClaimTypes.Role).FirstOrDefault()?.Value;
                var userTD = claims.Where(x => x.Type == "userTD").FirstOrDefault()?.Value;
            // or
            ViewBag.MessageNom = $"Le Nom est : {NomUserLogged} et son Role {userRole}";

            }
            return View();
        }

        [Route("/privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        [Route("/error")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}