using WEB_API_1_Paskaita.Controllers.Data.Dto;
using WEB_API_1_Paskaita.Models;

namespace WEB_API_1_Paskaita.Services
{
    public class FoodExpiryService : IFoodExpiryService
    {
        public FoodExpiryService(IFoodStoreService foodStoreService)
        {
            _foodStoreService = foodStoreService;
        }

        private readonly IFoodStoreService _foodStoreService;


        public void AddExpirationDateTime(int foodId)
        {
            var founFood = _foodStoreService.FoodList.FirstOrDefault(f => f.Id == foodId);
            founFood.ExpirationDateTime = DateTime.Now.AddDays(50);
        }
    }

    public interface IFoodExpiryService
    {
        public void AddExpirationDateTime(int foodId);
    }
}

