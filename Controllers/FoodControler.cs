using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_API_1_Paskaita.Controllers.Data;
using WEB_API_1_Paskaita.Controllers.Models;
using WEB_API_1_Paskaita.Services;

namespace WEB_API_1_Paskaita.Controllers
{
    [Route("api/food")]
    [ApiController]
    public class FoodControler : ControllerBase
    {
        private readonly IFoodStoreService _foodStoreService;
        private readonly IFoodExpiryService _foodExpiryService;

        public FoodControler( IFoodStoreService foodStoreservice, IFoodExpiryService foodExpiryService) 
        {
            _foodStoreService = foodStoreservice;
            _foodExpiryService = foodExpiryService;

        }
        [HttpGet("all")]
        public IEnumerable<Food> GetAllFood()
        {
            _foodExpiryService.AddExpirationDateTime(5);
            return _foodStoreService.FoodList;

        }

        [HttpGet("{id:int}", Name = "GetFood")]
        public Food? GetById(int Id)
        {
            if(Id == 0)
            {
                return null;
            }
            var foodProduct = _foodStoreService.FoodList.FirstOrDefault(fp => fp.Id == Id);

            return foodProduct;
        }

        [HttpPost]
        public Food CreateFood(Food food)
        {
            if (food == null)
            {
                return null;
            }
            if (food.Id > 0)
            {
                return null;
            }
            int getLastFoodId = _foodStoreService.FoodList.Max(fp => fp.Id);

            food.Id = getLastFoodId + 1;
            _foodStoreService.FoodList.Add(food);

            return food;
        }

        [HttpDelete("{id:int}", Name = "DeleteFood")]
        public void DeleteFood(int id)
        {
            var foodToDelete = _foodStoreService.FoodList.FirstOrDefault(f=>f.Id == id);
            _foodStoreService.FoodList.Remove(foodToDelete);
        }
        
        [HttpPut("{id:int}", Name = "UpdateFood")]
        public void UpdateFood (int id,Food food)
        {
            var foodToUpdate = _foodStoreService.FoodList.FirstOrDefault(f=> f.Id == id);
            foodToUpdate.Name = food.Name;
            foodToUpdate.Country = food.Country;
            foodToUpdate.Weight = food.Weight;

        }
    }
}
