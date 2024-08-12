using Microsoft.AspNetCore.Mvc;
using Web_Api.Domain.Models;
using WEB_API_1_Paskaita.Controllers.Data.Dto;
using WEB_API_1_Paskaita.Interfaces;


namespace WEB_API_1_Paskaita.Controllers
{
    [Route("api/safetycar")]
    [ApiController]
    public class SafetyCarController : ControllerBase
    {
        private readonly ISafetyCarService _safetyCarService;
        private readonly ILogger _logger;

        public SafetyCarController(ISafetyCarService safetyCarService, ILogger<SafetyCarController> logger)
        {
            _safetyCarService = safetyCarService;
            _logger = logger;
        }
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SafetyCar>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<SafetyCar>>> GetAllSafetyCarsAsync()
        {
            try
            {
                var allSafetyCars = await _safetyCarService.GetAllSafetyCarsAsync();
                if (!allSafetyCars.Any())
                {
                    return NotFound();
                }
                return Ok(allSafetyCars);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "An error occurred while get all safety cars.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
            
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SafetyCar>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<SafetyCar>>> GetSafetyCarByColorAsync([FromQuery]string color)
        {
            try
            {
                if (color == null)
                {
                    return BadRequest();
                }
                var safetyCarByColor = await _safetyCarService.GetSafetyCarByColorAsync(color);
                if (!safetyCarByColor.Any())
                {
                    return NotFound();
                }
                return Ok(safetyCarByColor);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "An error occurred while get safety car by color.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateSafetyCarAsync(SafetyCar safetyCar)
        {
            try
            {
                if(safetyCar == null)
                {
                    return NotFound();
                }
                if(safetyCar.Id > 0)
                {
                    return BadRequest();
                }
                await _safetyCarService.CreateSafetyCarAsync(safetyCar);
                return Created();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "An error occurred while create safety car.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateSafetyCarAsync([FromQuery] int id, [FromBody] SafetyCar safetyCar)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest();
                }
                if (safetyCar == null)
                {
                    return NotFound();
                }
                var safetyCarToUpdate = await _safetyCarService.GetSafetyCarByIDAsync(safetyCar.Id);
                if (safetyCarToUpdate == null)
                {
                    return NotFound();
                }
                else
                {
                    await _safetyCarService.UpdateSafetyCarAsync(safetyCarToUpdate, safetyCar);
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "An error occurred while update safety car.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
        [HttpDelete("{id:int}", Name ="DeleteSafetyCar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteSafetyCarAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest();
                }
                var safetyCarToDelete = await _safetyCarService.GetSafetyCarByIDAsync(id);
                if (safetyCarToDelete == null)
                {
                    return NotFound();
                }
                else
                {
                    await _safetyCarService.DeleteSafetyCarAsync(safetyCarToDelete);
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "An error occurred while delete safety car.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
