using Microsoft.AspNetCore.Mvc;
using WEB_API_1_Paskaita.Interfaces;
using WEB_API_1_Paskaita.Models;

namespace WEB_API_1_Paskaita.Controllers
{
    [Route("api/safetycar")]
    [ApiController]
    public class SafetyCarController : ControllerBase
    {
        public readonly ISafetyCarService _safetyCarService;

        public SafetyCarController(ISafetyCarService safetyCarService)
        {
            _safetyCarService = safetyCarService;
        }
        [HttpGet("all")]
        public IEnumerable<SafetyCar> GetAllSafetyCars()
        {
            return _safetyCarService.GetAllSafetyCars();
        }
        [HttpGet]
        public IEnumerable<SafetyCar> GetSafetyCarByColor([FromQuery]string color)
        {
            return _safetyCarService.GetSafetyCarByColor(color);
        }
        [HttpPost]
        public SafetyCar CreateSafetyCar(SafetyCar safetyCar)
        {
            return _safetyCarService.CreateSafetyCar(safetyCar);
        }
        [HttpPut]
        public void UpdateSafetyCar([FromQuery] int id, [FromBody] SafetyCar safetyCar)
        {
            _safetyCarService.UpdateSafetyCar(id, safetyCar);
        }
        [HttpDelete("{id:int}", Name ="DeleteSafetyCar")]
        public void DeleteSafetyCar(int id)
        {
            _safetyCarService.DeleteSafetyCar(id);
        }
    }
}
