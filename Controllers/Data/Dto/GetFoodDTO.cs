
using Web_Api.Domain.Models;

namespace WEB_API_1_Paskaita.Controllers.Data.Dto
{
    public class GetFoodDTO(Food food)
    {

        public string Name { get; set; } = food.Name;
        public string Country { get; set; } = food.Country;
        public double Weight { get; set; } = food.Weight;
        public DateTime ExpirationDateTime { get; set; } = food.ExpirationDateTime;
    }
}
