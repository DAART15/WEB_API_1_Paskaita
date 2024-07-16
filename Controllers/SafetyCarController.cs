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
        public async Task<IEnumerable<SafetyCar>> GetAllSafetyCarsAsync()
        {
            return await _safetyCarService.GetAllSafetyCarsAsync();
        }
        [HttpGet]
        public async Task<IEnumerable<SafetyCar>> GetSafetyCarByColorAsync([FromQuery]string color)
        {
            return await _safetyCarService.GetSafetyCarByColorAsync(color);
        }
        [HttpPost]
        public async Task<SafetyCar> CreateSafetyCarAsync(SafetyCar safetyCar)
        {
            return await _safetyCarService.CreateSafetyCarAsync(safetyCar);
        }
        [HttpPut]
        public async Task UpdateSafetyCarAsync([FromQuery] int id, [FromBody] SafetyCar safetyCar)
        {
            await _safetyCarService.UpdateSafetyCarAsync(id, safetyCar);
        }
        [HttpDelete("{id:int}", Name ="DeleteSafetyCar")]
        public async Task DeleteSafetyCarAsync(int id)
        {
            await _safetyCarService.DeleteSafetyCarAsync(id);
        }
    }
}
