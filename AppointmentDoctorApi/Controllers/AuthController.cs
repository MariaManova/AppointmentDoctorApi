using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AppointmentDoctorApi.Models;
using AppointmentDoctorApi.Models.Enumerations;
using AppointmentDoctorApi.Models.Helpers;
using AppointmentDoctorApi.Models.Services;
using AppointmentDoctorApi.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AppointmentDoctorApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserService userService;
        private readonly IConfiguration config;

        public AuthController(IUserService userService, IConfiguration config)
        {
            this.userService = userService;
            this.config = config;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost("signup")]
        public IActionResult Create([FromBody] RegisterUserViewModel model)
        {
            model.Role = (int)Role.user;
            try
            {
                var user = userService.Create((User)model, model.Address, model.Password);
                return Ok(user);
            }
            catch (AppException e)
            {
                return BadRequest(new
                {
                    message = e.Message
                });
            }
            catch
            {
                return BadRequest(new
                {
                    message = "Произошла ошибка, попробуйте позже"
                });
            }
        }

        [AllowAnonymous]
        [HttpPost("signin")]
        public IActionResult Authenticate([FromBody] AuthUserViewModel model)
        {
            if (model == null || model.Email == null || model.Password == null)
                return BadRequest(new { message = "Email или пароль не валидны" });

            var user = userService.Authenticate(model.Email, model.Password);

            if (user == null)
                return BadRequest(new { message = "Email или пароль не валидны" });

            var tokenString = GetToken(user);
            var patientAuth = userService.Get(user.Id);

            return Ok(new
            {
                token = tokenString,
                patient = patientAuth,
                userLogin = user
            });
        }
        private string GetToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("Config:SecretKey");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Enum_Role.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}
