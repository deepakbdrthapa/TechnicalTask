using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Models;
using PaymentAPI.Repository;
using System.Net;

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       
        public IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpPost, Route("GenerateToken")]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            IActionResult response = new JsonResult(new
            {
                Message = "Invalid Username or Password.",
            })
            {
                StatusCode = (int)HttpStatusCode.Unauthorized
            };
            AuthenticateResponse authenticateResponse = GenerateToken(userLogin);

            if (authenticateResponse == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            return Ok(authenticateResponse);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public AuthenticateResponse GenerateToken(UserLogin userLogin)
        {
            var user = _userRepository.GetUser(userLogin.UserName, userLogin.Password).Result;
            if (user == null) return null;

            var token = _userRepository.GenerateToken(userLogin);

            return new AuthenticateResponse(user, token);
        }
    }
}
