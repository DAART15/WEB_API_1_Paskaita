using WEB_API_1_Paskaita.Interfaces;
using WEB_API_1_Paskaita.Models;

namespace WEB_API_1_Paskaita.Services
{
    public class SafetyCarService : ISafetyCarService
    {
        private readonly ISafetyCarRepository _safetyCarRepository;

        public SafetyCarService(ISafetyCarRepository safetyCarRepository)
        {
            _safetyCarRepository = safetyCarRepository;
        }
        public async Task<IEnumerable<SafetyCar>> GetAllSafetyCarsAsync()
        {
            return await _safetyCarRepository.GetSafetyCarsAsinc();
        }

        public async Task<IEnumerable<SafetyCar>> GetSafetyCarByColorAsync( string color)
        {
            if (string.IsNullOrEmpty(color) || string.IsNullOrWhiteSpace(color))
            {
                return null;
            }
            var allsafetyCars = await GetAllSafetyCarsAsync();
            return allsafetyCars.Where(c => c.Color.ToLower() == color.ToLower());
        }
        public async Task<SafetyCar> CreateSafetyCarAsync(SafetyCar safetyCar)
        {
            if(safetyCar.Id == null)
            {
                return null ;
            }
            if(safetyCar.Id > 0)
            {
                return null;
            }
            var allsafetyCars = await GetAllSafetyCarsAsync();
            int lastSafetyCarId = allsafetyCars.Max(c => c.Id);
            safetyCar.Id = lastSafetyCarId+1;
            await _safetyCarRepository.AddSafetyCarAsync(safetyCar);
            return safetyCar;
        }
        public async Task UpdateSafetyCarAsync(SafetyCar safetyCarToUpdate, SafetyCar safetyCar)
        {
            safetyCarToUpdate.Brand = safetyCar.Brand;
            safetyCarToUpdate.Model = safetyCar.Model;
            safetyCarToUpdate.Color = safetyCar.Color;
            await _safetyCarRepository.UpdateSafetyCarAsync(safetyCarToUpdate);
        }
        public async Task DeleteSafetyCarAsync(SafetyCar safetyCarToDelete)
        {
            await _safetyCarRepository.DeleteSafetyCarAsync(safetyCarToDelete);
        }
        public async Task<SafetyCar>GetSafetyCarByIDAsync(int id)
        {
            var allSafetyCars = await GetAllSafetyCarsAsync();
            return allSafetyCars.FirstOrDefault(s => s.Id == id);
        }
    }
}
