using Microsoft.EntityFrameworkCore;
using WEB_API_1_Paskaita.DataBase;
using WEB_API_1_Paskaita.Interfaces;
using WEB_API_1_Paskaita.Models;

namespace WEB_API_1_Paskaita.Services.Repositories
{
    public class SafetyCarRepository : ISafetyCarRepository
    {
        private readonly AplicationDbContext _dbContext;

        public SafetyCarRepository(AplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IList<SafetyCar>> GetSafetyCarsAsinc()
        {
            return await _dbContext.SafetyCars.ToListAsync();
        }
        public async Task AddSafetyCarAsync(SafetyCar safetyCar)
        {
            _dbContext.SafetyCars.Add(safetyCar);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateSafetyCarAsync(SafetyCar safetyCar)
        {
            _dbContext.SafetyCars.Update(safetyCar);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteSafetyCarAsync(SafetyCar safetyCar)
        {
            _dbContext.SafetyCars.Remove(safetyCar);
            await _dbContext.SaveChangesAsync();
        }
    }
}
