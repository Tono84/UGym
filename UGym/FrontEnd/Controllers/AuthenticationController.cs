using Microsoft.AspNetCore.Mvc;
using FrontEnd.Models.Authentication;
using BackEnd.Models.Authentication.SignUp;
using FrontEnd.Helpers;
using System.Text.Json;
using System.Text;

namespace FrontEnd.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(ILogger<AuthenticationController> logger)
        {
            _logger = logger;
        }

        Authentication api = new Authentication();


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser registerUser)
        {
            try
            {
                string data = JsonSerializer.Serialize(registerUser);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpClient client = api.Initial();
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Authentication", content);
                if(response != null && response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Home", "Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error in API Request");
                    return View(registerUser);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error in API Request: " + ex.Message);
                return View(registerUser);
            }
            
        }
    }
}
