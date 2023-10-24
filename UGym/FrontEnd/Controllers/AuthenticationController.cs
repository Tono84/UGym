using Microsoft.AspNetCore.Mvc;
using FrontEnd.Models.Authentication;
using BackEnd.Models.Authentication.SignUp;

namespace FrontEnd.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(ILogger<AuthenticationController> logger)
        {
            _logger = logger;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUser registerUser)
        {

            return View();
        }
    }
}
