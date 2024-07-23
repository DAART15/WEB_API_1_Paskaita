using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_API_1_Paskaita.Controllers.Data;
using WEB_API_1_Paskaita.Controllers.Data.Dto;
using WEB_API_1_Paskaita.Interfaces;
using WEB_API_1_Paskaita.Models;

namespace WEB_API_1_Paskaita.Controllers
{
    [Route("api/contact")]
    [ApiController]
    public class ContactController(IContactRepositoryService _contactRepositoryService, IContactMapper _contactMaper, ILogger<ContactController> _logger) : ControllerBase
    {
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<GetContactDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<GetContactDTO>>> GetAllContacts()
        {
            try
            {
                var contacts = await _contactRepositoryService.GetALLContactsAsync();
                if (contacts == null || !contacts.Any())
                {
                    return NotFound();
                }
                var contactsWithoutDate = contacts.Select(_contactMaper.DateLess).ToList();
                return Ok(contactsWithoutDate);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "An error occurred while get all contacts.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Contact))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Contact>>GetContactById([FromQuery]int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest();
                }
                var contact = await _contactRepositoryService.GetContactByIdAsync(id);
                if (contact == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(contact);
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "An error occurred while get contact by id.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult>UpdateContact([FromQuery] int id,[FromBody] Contact contact)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest();
                }
                if (contact == null)
                {
                    return NotFound();
                }
                var contactToUpdate = await _contactRepositoryService.GetContactByIdAsync(id);
                if (contactToUpdate == null)
                {
                    return NotFound();
                }
                else
                {
                    await _contactRepositoryService.UpdateContactAsync(contactToUpdate, contact);
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "An error occurred while update contact.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateContact([FromBody] Contact contact)
        {
            try
            {
                if (contact == null)
                {
                    return NotFound();
                }
                if (contact.Id > 0)
                {
                    return BadRequest();
                }
                await _contactRepositoryService.CreateContactAsync(contact);
                return Created();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "An error occurred while create contact.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
            
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteContact([FromQuery] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest();
                }
                var contactToDele = await _contactRepositoryService.GetContactByIdAsync(id);
                if (contactToDele == null)
                {
                    return NotFound();
                }
                else
                {
                    await _contactRepositoryService.DeleteContactAsync(contactToDele);
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "An error occurred while deleting contact.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
            
        }
        [HttpGet("sort")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Contact>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Contact>>> SortContactsBy([FromQuery] string v)
        {
            try
            {
                var contacts = await _contactRepositoryService.GetALLContactsAsync();
                if (contacts == null || !contacts.Any())
                {
                    return NotFound();
                }
                switch (v)
                {
                    case "nameaz":
                        var sortedContactsByNameAZ = contacts.OrderBy(c => c.FirstName).ToList();
                        return Ok(sortedContactsByNameAZ);
                    case "nameza":
                        var sortedContactsByNameZA = contacts.OrderByDescending(c => c.FirstName).ToList();
                        return Ok(sortedContactsByNameZA);
                    case "companyaz":
                        var sortedContactsByCompanyAZ = contacts.OrderBy(c => c.Company).ToList();
                        return Ok(sortedContactsByCompanyAZ);
                    case "companyza":
                        var sortedContactsByCompanyZA = contacts.OrderByDescending(c => c.Company).ToList();
                        return Ok(sortedContactsByCompanyZA);
                    case "lastu":
                        var sortedContactsByLastUpdated = contacts.OrderByDescending(c => c.UpdatedAt).ToList();
                        return Ok(sortedContactsByLastUpdated);
                    case "lastc":
                        var sortedContactsByLastCreated = contacts.OrderByDescending(c => c.CreatedAt).ToList();
                        return Ok(sortedContactsByLastCreated);
                    default:
                        return BadRequest();
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "An error occurred while sorting contacts.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
            
        }
    }
}
