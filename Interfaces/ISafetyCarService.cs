using WEB_API_1_Paskaita.Models;

namespace WEB_API_1_Paskaita.Interfaces
{
    public interface ISafetyCarService
    {
        public Task<IEnumerable<SafetyCar>> GetAllSafetyCarsAsync();
        public Task<IEnumerable<SafetyCar>> GetSafetyCarByColorAsync(string color);
        public Task CreateSafetyCarAsync(SafetyCar safetyCar);
        public Task UpdateSafetyCarAsync(SafetyCar safetyCarToUpdate, SafetyCar safetyCar);
        public Task DeleteSafetyCarAsync(SafetyCar safetyCarToDelete);
        public Task<SafetyCar> GetSafetyCarByIDAsync(int id);
    }
}
