using WEB_API_1_Paskaita.Models;

namespace WEB_API_1_Paskaita.Interfaces
{
    public interface ISafetyCarService
    {
        public Task<IEnumerable<SafetyCar>> GetAllSafetyCarsAsync();
        public Task<IEnumerable<SafetyCar>> GetSafetyCarByColorAsync(string color);
        public Task<SafetyCar> CreateSafetyCarAsync(SafetyCar safetyCar);
        public Task UpdateSafetyCarAsync(int id, SafetyCar safetyCar);
        public Task DeleteSafetyCarAsync(int id);
    }
}
