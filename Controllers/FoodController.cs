using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Api.Domain.Models;
using Web_Api.Domain.Services;
using WEB_API_1_Paskaita.Controllers.Data.Dto;

using WEB_API_1_Paskaita.Services;

namespace WEB_API_1_Paskaita.Controllers
{
    [Route("api/food")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodStoreService _foodStoreService;
        private readonly IFoodExpiryService _foodExpiryService;
        private readonly IFoodMaper _foodMaper;

        public FoodController( IFoodStoreService foodStoreservice, IFoodExpiryService foodExpiryService, IFoodMaper foodMaper, IBusnesService _busnesService) 
        {
            _foodStoreService = foodStoreservice;
            _foodExpiryService = foodExpiryService;
            _foodMaper = foodMaper;
        }
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Food>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<Food>> GetAllFood()
        {
            _foodExpiryService.AddExpirationDateTime(5);
            var response = _foodStoreService.FoodList
                .Select(_foodMaper.Bind)
                .ToList();
            return Ok(_foodStoreService.FoodList);

        }

        [HttpGet("{id:int}", Name = "GetFood")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Food))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Food?> GetById(int Id)
        {
            if(Id <= 0)
            {
                return BadRequest();
            }
            var foodProduct = _foodStoreService.FoodList.FirstOrDefault(fp => fp.Id == Id);
            if(foodProduct == null)
            {
                return NotFound();
            }
            return Ok(foodProduct);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Food))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Food> CreateFood(Food food)
        {
            if (food == null)
            {
                return NotFound();
            }
            if (food.Id > 0)
            {
                return BadRequest();
            }
            int getLastFoodId = _foodStoreService.FoodList.Max(fp => fp.Id);

            food.Id = getLastFoodId + 1;
            _foodStoreService.FoodList.Add(food);

            return CreatedAtRoute("GetFood", new {id= food.Id }, food);
        }

        [HttpDelete("{id:int}", Name = "DeleteFood")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteFood(int id)
        {
            var foodToDelete = _foodStoreService.FoodList.FirstOrDefault(f=>f.Id == id);
            _foodStoreService.FoodList.Remove(foodToDelete);
            return NoContent();
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
