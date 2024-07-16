using WEB_API_1_Paskaita.Interfaces;
using WEB_API_1_Paskaita.Models;

namespace WEB_API_1_Paskaita.Controllers.Data.Dto
{
    public class SafetyCarDataService : ISafetyCarDataService
    {
        public List<SafetyCar> SafetyCarList { get; set; } =new List<SafetyCar>() 
        { 
            new SafetyCar(1, "Aston Martin", "Vantage", "Green Metalic"),
            new SafetyCar(2, "Mercedes-Benz", "AMG GT Black Series", "Black"),
            new SafetyCar(3, "Mercedes-Benz", "AMG GT R", "Silver"),
            new SafetyCar(4, "Lamborghini", "Diablo", "Red"),
        };
    }
}
