using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEB_API_1_Paskaita.Controllers
{
    [Route("api/food")]
    [ApiController]
    public class FoodControler : ControllerBase
    {
        [HttpGet("all")]
        public IEnumerable<string> GetAllFood()
        {
            var allFoods = new List<string>();
            allFoods.Add("Pizza");
            allFoods.Add("Tomatoes");
            allFoods.Add("Potatoes");

            return allFoods;
        }
    }
}
