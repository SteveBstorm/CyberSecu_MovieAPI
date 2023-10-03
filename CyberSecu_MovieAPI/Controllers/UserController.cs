using CyberSecu_MovieAPI.DTOs;
using CyberSecu_MovieAPI.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI_DAL.Models;
using MovieAPI_DAL.Repos;
using Swashbuckle.AspNetCore.Annotations;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace CyberSecu_MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly TokenGenerator _tokenGenerator;
        public UserController(IUserService userService, TokenGenerator tokenGenerator)
        {
            _userService = userService;
            _tokenGenerator = tokenGenerator;
        }
       //[SwaggerResponse(int.Parse(HttpStatusCode.NotFound), Type = typeof(NotFoundResult))]
        //[Authorize("ModoPolicy")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetUsers());
        }

        //[Authorize("AdminPolicy")]
        [HttpPatch("setRole")]
        public IActionResult ChangeRole(ChangeRole r)
        {
            _userService.SetRole(r.UserId, r.RoleId);
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login(UserLogin user)
        {
            try
            {
                User connectedUser = _userService.LoginUser(user.Email, user.Password);
                return Ok(_tokenGenerator.GenerateToken(connectedUser));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register")]
        public IActionResult Register(NewUser user)
        {
            _userService.RegisterUser(user.Nickname, user.Email, user.Password);
            return Ok();
        }

        [HttpGet("getProfile")]
        public IActionResult GetProfile()
        {
            //var t = User.Claims.First(c => c.Type == ClaimTypes.Sid);
            string token = Request.Headers.Authorization.ToString().Substring(8);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwt = handler.ReadJwtToken(token);
            
            return Ok(jwt.Claims);
        }
    }
}
