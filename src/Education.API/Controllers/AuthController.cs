using Education.Application.UseCases.AuthServise;
using Education.Application.UseCases.EmailService;
using Education.Domain.DTOS;
using Education.Domain.Entities.Auth;
using Education.Domain.Entities.DemoModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase 
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly IAuthServise _authService;
        private readonly ISendEmailService _sendEmailService;

        public AuthController(UserManager<UserModel> userManager, IAuthServise authService, ISendEmailService sendEmailService)
        {
            _userManager = userManager;
            _authService = authService;
            _sendEmailService = sendEmailService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO register)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception();
            }
            var user = new UserModel()
            {
                FullName = register.FullName,
                Country = register.Country,
                UserName = register.Username,
                Email = register.Email,
                
            };

            var result = await _userManager.CreateAsync(user, register.Password);
            await _sendEmailService.SendEmailAsync(new EmailModel
            {
                Body=$"{user.FullName} registratsiyadan otganingiz bilan tabriklaydi Abduxoliq",
                Subject="EdFix",
                To=$"{user.Email}"
            });

            if (!result.Succeeded)
                throw new Exception();

            await _userManager.AddToRoleAsync(user, "User");

            return Ok(new ResponseModel()
            {
                IsSuccess = true,
                Message = "Successfully Created",
                StatusCode = 201
            });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception();
            }
            var user = await _userManager.FindByEmailAsync(login.Email);

            if (user == null)
            {
                return BadRequest(new TokenDTO()
                {
                    Message = "User  not found",
                    IsSucceed = false,
                    Token = ""
                });
            }

            var checker = await _userManager.CheckPasswordAsync(user, login.Password);
            if (!checker)
            {
                return BadRequest(new TokenDTO()
                {
                    Message = "Password not match",
                    IsSucceed = false,
                    Token = ""
                });
            }

            var token = await _authService.GenerateToken(user);

            return Ok(new TokenDTO()
            {
                Token = token,
                IsSucceed = true,
                Message = "Success"
            });

        }

        [HttpPost]
        public async Task<ResponseModel> ForgotPassword(string email)
        {
            var user=await _userManager.FindByEmailAsync(email);
            if(user == null)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = "Email not Found",
                    StatusCode = 404
                };
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var random=new Random();

            var password = $"Demo!{random.Next(1000, 9999)}";


            await _userManager.ResetPasswordAsync(user, token, password);

            await _sendEmailService.SendEmailAsync(new EmailModel
            {
                Body = $"Your new Password {password}",
                Subject = "Password",
                To = email
            });

            return new ResponseModel
            {
                IsSuccess = true,
                Message = "reset",
                StatusCode = 200
            };

        }
    }
}

