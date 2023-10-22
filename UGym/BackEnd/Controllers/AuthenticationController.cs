using BackEnd.Areas.Identity.Data;
using BackEnd.Models;
using BackEnd.Models.Authentication.SignUp;
using BackEnd.Service.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETCore.MailKit.Core;
using BackEnd.Service.Services;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<UGymUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly Service.Services.IEmailService _emailService;

        public AuthenticationController(UserManager<UGymUser> userManager,
            RoleManager<IdentityRole> roleManager, Service.Services.IEmailService emailService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterUser registerUser, string role)
        {
            #region Check User Exist
            var userExit = await _userManager.FindByEmailAsync(registerUser.Email);
            if (userExit != null)
            {
                return StatusCode(StatusCodes.Status403Forbidden,
                    new Response { Status = "Error", Message = "User Already Exists!" });
            }
            #endregion

            #region Add User in DataBase
            UGymUser user = new()
            {
                Email = registerUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerUser.Username
            };
            if (await _roleManager.RoleExistsAsync(role))
            {
                var result = await _userManager.CreateAsync(user, registerUser.Password);
                if (!result.Succeeded)
                {
                    return (IActionResult)StatusCode(StatusCodes.Status500InternalServerError,
                        new Response { Status = "Error", Message = "User Failed to Created!" });
                }

                #region Assign a Role to User
                await _userManager.AddToRoleAsync(user, role);
                #endregion

                #region Add Token to Verify Email
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action(nameof(ConfirmEmail), "Authentication", new { token, email = user.Email }, Request.Scheme);
                var message = new Message(new string[] { user.Email! }, "Confirmation email link", confirmationLink!);
                _emailService.SendEmail(message);
                #endregion

                return (IActionResult)StatusCode(StatusCodes.Status200OK,
                    new Response { Status = "Success", Message = $"User Created Successfully & Confirmation Email Sent to: {user.Email}" });
            }
            else
            {
                return (IActionResult)StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message = "The Provided Role Doesn't Exist!" });
            }
            #endregion
        }

        [HttpGet]
        public IActionResult TestEmail()
        {
            var message = new Message(new string[]
                { "serranodennis16@gmail.com" }, "Test", "Test");
            _emailService.SendEmail(message);
            return StatusCode(StatusCodes.Status200OK,
                new Response { Status = "Success", Message = "Email Sent Successfully!"});
        }

        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status200OK,
                      new Response { Status = "Success", Message = "Email Verified Successfully!" });
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError,
                       new Response { Status = "Error", Message = "This User Doesn't Exist!" });
        }
    }
}