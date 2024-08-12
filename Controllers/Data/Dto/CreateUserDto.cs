using WEB_API_1_Paskaita.Attributes;

namespace WEB_API_1_Paskaita.Controllers.Data.Dto
{
    public class CreateUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        [MaxFileSize(5*1024*1024)] //5MB
        [AllowedExtension([".jpg", ".png"])]
        public IFormFile Image { get; set; }
    }
}
