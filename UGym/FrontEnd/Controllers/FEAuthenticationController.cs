using Microsoft.AspNetCore.Mvc;
using FrontEnd.Models.FEAuthentication;
using FrontEnd.Helpers;
using System.Text.Json;
using System.Text;
using System.Net;

namespace FrontEnd.Controllers
{
    public class FEAuthenticationController : Controller
    {
        private readonly ILogger<FEAuthenticationController> _logger;

        public FEAuthenticationController(ILogger<FEAuthenticationController> logger)
        {
            _logger = logger;
        }

        Authentication api = new Authentication();

      
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register register)
        {
            try
            {
                string data = JsonSerializer.Serialize(register);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpClient client = api.Initial();
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Authentication/Register", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var errors = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(responseContent);

                    foreach (var error in errors)
                    {
                        foreach (var errorMessage in error.Value)
                        {
                            ModelState.AddModelError(error.Key, errorMessage);
                        }
                    }

                    return View(register);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error in API Request");
                    return View(register);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error in API Request: " + ex.Message);
                return View(register);
            }
        }

    }
}
