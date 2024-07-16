using WEB_API_1_Paskaita.Interfaces;
using WEB_API_1_Paskaita.Models;

namespace WEB_API_1_Paskaita.Services
{
    public class SafetyCarService : ISafetyCarService
    {
        private readonly ISafetyCarDataService _safetyCarDataService;

        public SafetyCarService(ISafetyCarDataService safetyCarDataService)
        {
            _safetyCarDataService = safetyCarDataService;
        }
        public IEnumerable<SafetyCar> GetAllSafetyCars()
        {
            return _safetyCarDataService.SafetyCarList;
        }

        public IEnumerable<SafetyCar> GetSafetyCarByColor( string color)
        {
            if (string.IsNullOrEmpty(color) || string.IsNullOrWhiteSpace(color))
            {
                return null;
            }
            return _safetyCarDataService.SafetyCarList.Where(c => c.Color.ToLower() == color.ToLower());
        }
        public SafetyCar CreateSafetyCar(SafetyCar safetyCar)
        {
            if(safetyCar.Id == null)
            {
                return null ;
            }
            if(safetyCar.Id > 0)
            {
                return null;
            }
            int lastSafetyCarId = _safetyCarDataService.SafetyCarList.Max(c => c.Id);
            safetyCar.Id = lastSafetyCarId+1;
            _safetyCarDataService.SafetyCarList.Add(safetyCar);
            return safetyCar;
        }
        public void UpdateSafetyCar(int id, SafetyCar safetyCar)
        {
            var safetyCarToUpdate = _safetyCarDataService.SafetyCarList.FirstOrDefault(c =>c.Id == id);
            safetyCarToUpdate.Brand = safetyCar.Brand;
            safetyCarToUpdate.Model = safetyCar.Model;
            safetyCarToUpdate.Color = safetyCar.Color;
        }
        public void DeleteSafetyCar(int id)
        {
            var safetyCarToDelete =  _safetyCarDataService.SafetyCarList.FirstOrDefault(c =>c.Id == id);
            _safetyCarDataService.SafetyCarList.Remove(safetyCarToDelete);
        }
    }
}
