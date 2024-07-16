using WEB_API_1_Paskaita.Models;

namespace WEB_API_1_Paskaita.Interfaces
{
    public interface IUserRepository
    {
        public Task AddUserAsync(User user);
        public Task<IList<User>> GetUsersAsync();
    }
}
