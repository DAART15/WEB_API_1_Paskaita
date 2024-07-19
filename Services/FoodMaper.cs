using WEB_API_1_Paskaita.Controllers.Data.Dto;
using WEB_API_1_Paskaita.Models;

namespace WEB_API_1_Paskaita.Services
{
    public class FoodMaper : IFoodMaper
    {
        public GetFoodDTO Bind(Food food)
        {
            return new GetFoodDTO(food);
        }
    }

    public interface IFoodMaper
    {
        public GetFoodDTO Bind(Food food);
    }
}
