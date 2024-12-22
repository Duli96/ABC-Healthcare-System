using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AuthService.Services;
using AuthService.Models;
using AuthService.Helpers;
using AuthService.DTOs;

namespace AuthService.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthService authService, HttpClient httpClient, IConfiguration configuration)
        {
            _authService = authService;
            _httpClient = httpClient;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_configuration["UserService:BaseUrl"]}/api/user/validate",new { request.Email, request.Password });

            if (!response.IsSuccessStatusCode)
            {
                return Unauthorized("Invalid email or password.");
            }

            var user = await response.Content.ReadFromJsonAsync<UserResponse>();
            
            var token = JwtHelper.GenerateJwtToken(user, _configuration["Jwt:Key"]);
            return Ok(token.ToString());

        }
    }

    
}
