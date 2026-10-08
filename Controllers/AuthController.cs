using Fullstack.SwaggerIntergration.Models;
using Fullstack.SwaggerIntergration.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fullstack.SwaggerIntergration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        /// <summary>
        /// Authenticates a user and returns a JWT access token.
        /// </summary>
        /// <param name="request">User login credentials.</param>
        /// <returns>A JWT access token.</returns>
        /// <response code="200">Authentication successful.</response>
        /// <response code="401">Invalid credentials.</response>
        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Login(LoginRequest request)
        {
            if (request.Email != "admin@devstore.com" ||
                request.Password != "Admin@123")
            {
                return Unauthorized(new
                {
                    message = "Invalid email or password."
                });
            }

            var response =
                _tokenService.GenerateToken(request.Email);

            return Ok(response);
        }
    }

}
