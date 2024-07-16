using WEB_API_1_Paskaita.Models;

namespace WEB_API_1_Paskaita.Interfaces
{
    public interface ISafetyCarDataService
    {
        public List<SafetyCar> SafetyCarList { get; set; }
    }
}
