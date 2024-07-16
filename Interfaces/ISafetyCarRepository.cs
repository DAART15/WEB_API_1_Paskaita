using WEB_API_1_Paskaita.Models;

namespace WEB_API_1_Paskaita.Interfaces
{
    public interface ISafetyCarRepository
    {
        public Task<IList<SafetyCar>> GetSafetyCarsAsinc();
        public Task AddSafetyCarAsync(SafetyCar safetyCar);
        public Task UpdateSafetyCarAsync(SafetyCar safetyCar);
        public Task DeleteSafetyCarAsync(SafetyCar safetyCar);
    }
}
