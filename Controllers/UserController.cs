using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_API_1_Paskaita.Interfaces;
using WEB_API_1_Paskaita.Models;

namespace WEB_API_1_Paskaita.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserRepository userRepository, ILogger<UserController> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _userRepository.GetUsersAsync();

            if (users.Count < 5)
                _logger.LogWarning("There are less than 5 users in the database");

            _logger.LogInformation("Returning {0} users", users.Count);

            return users;
        }
        [HttpPost]
        public async Task CreateUser([FromBody] User request)
        {
            if (string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.Email))
            {
                _logger.LogError("User name or email is missing");
            }

            request.Id = Guid.NewGuid();

            await _userRepository.AddUserAsync(request);
        }
    }
}
