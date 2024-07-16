using Microsoft.EntityFrameworkCore;
using WEB_API_1_Paskaita.DataBase;
using WEB_API_1_Paskaita.Interfaces;
using WEB_API_1_Paskaita.Models;

namespace WEB_API_1_Paskaita.Services.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AplicationDbContext _dbContext;

        public UserRepository(AplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddUserAsync(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IList<User>> GetUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

    }
}
