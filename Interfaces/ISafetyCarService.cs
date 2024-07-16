using WEB_API_1_Paskaita.Models;

namespace WEB_API_1_Paskaita.Interfaces
{
    public interface ISafetyCarService
    {
        public IEnumerable<SafetyCar> GetAllSafetyCars();
        public IEnumerable<SafetyCar> GetSafetyCarByColor(string color);
        public SafetyCar CreateSafetyCar(SafetyCar safetyCar);
        public void UpdateSafetyCar(int id, SafetyCar safetyCar);
        public void DeleteSafetyCar(int id);
    }
}
