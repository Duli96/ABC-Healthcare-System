using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using AuthService.Helpers;
using AuthService.Models;

namespace AuthService.Services
{
    public class AuthServiceImpl : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public AuthServiceImpl(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<string?> LoginAsync(string email, string password)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_configuration["UserService:BaseUrl"]}/api/user/validate", new { email, password });

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var user = await response.Content.ReadFromJsonAsync<UserResponse>();

            if (user == null)
            {
                return null;
            }

            var token = JwtHelper.GenerateJwtToken(user, _configuration["Jwt:Key"]);
            return token;
        }
    }
}
