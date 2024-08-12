using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Api.Domain.Models;
using Web_Api.Infrastructure.Interfaces;
using WEB_API_1_Paskaita.Controllers.Data.Dto;

using WEB_API_1_Paskaita.Utilities;

namespace WEB_API_1_Paskaita.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserController> _logger;
        private readonly IWebHostEnvironment _environment;

        public UserController(IUserRepository userRepository, IWebHostEnvironment environment,  ILogger<UserController> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
            _environment = environment;
        }
        [HttpGet]
        //[Authorize]
        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _userRepository.GetUsersAsync();

            if (users.Count < 5)
                _logger.LogWarning("There are less than 5 users in the database");

            _logger.LogInformation("Returning {0} users", users.Count);

            return users;
        }
        [HttpPost]
        public async Task CreateUser([FromForm] CreateUserDto request)
        {
            if (string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.Email))
            {
                _logger.LogError("User name or email is missing");
            }

            var uploadFolderPath = Path.Combine(_environment.WebRootPath, "upload");
            if(!Directory.Exists(uploadFolderPath))
            {
                Directory.CreateDirectory(uploadFolderPath);
            }
            var filePath = Path.Combine(uploadFolderPath, request.Image.FileName);
            using var stream = new FileStream(filePath, FileMode.Create);
            await request.Image.CopyToAsync(stream);

            var user = new User
            {
                UserName = request.UserName,
                Email = request.Email,
                Id = Guid.NewGuid(),
                FileName = request.Image?.FileName,
                FileData = await FileUtility.ConvertToByte(request.Image),
            };
            await _userRepository.AddUserAsync(user);
        }
        [HttpGet("DownloadImage")]
        public async Task<IActionResult> DownloadAwatar([FromQuery] Guid id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return File(user.FileData, "image/jpeg", user.FileName);

        }
        
    }
}
