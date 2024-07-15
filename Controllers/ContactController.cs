using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_API_1_Paskaita.Controllers.Data;
using WEB_API_1_Paskaita.Interfaces;
using WEB_API_1_Paskaita.Models;

namespace WEB_API_1_Paskaita.Controllers
{
    [Route("api/contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactDataService _contactDataService;
        private readonly IContactUpdateService _contactUpdateService;

        public ContactController(IContactDataService contactDataService, IContactUpdateService contactUpdateService)
        {
            _contactDataService = contactDataService;
            _contactUpdateService = contactUpdateService;
        }
        [HttpGet("all")]
        public IEnumerable<Contact> GetAllContacts()
        {
            return _contactDataService.ContactList;
        }
        [HttpGet("{id:int}", Name ="GetContact")]
        public Contact GetContactById(int id)
        {
            var contact = _contactDataService.ContactList.FirstOrDefault(c=>c.Id == id);
            return contact;
        }
        [HttpPut("{id:int}", Name = "UpdateContact")]
        public void UpdateContact(int id, Contact contact)
        {
            _contactUpdateService.ChangeContactUpdateDateTime(id);
            var contactToUpdate = _contactDataService.ContactList.FirstOrDefault(c => c.Id == id);
            contactToUpdate.FirstName = contact.FirstName;
            contactToUpdate.LastName = contact.LastName;
            contactToUpdate.Company = contact.Company;
            contactToUpdate.PhoneNumber = contact.PhoneNumber;
            contactToUpdate.Mail = contact.Mail;
            contactToUpdate.Note = contact.Note;
        }
        [HttpPost]
        public Contact CreateContact(Contact contact)
        {
            if (contact == null)
            {
                return null;
            }
            if (contact.Id > 0)
            {
                return null;
            }
            int getLastContactId = _contactDataService.ContactList.Max(c => c.Id);
            contact.Id = getLastContactId+1;
            _contactDataService.ContactList.Add(contact);
            return contact;
        }
        [HttpDelete("{id:int}", Name = "DeleteContact")]
        public void DeleteContact(int id)
        {
            var contactToDelete = _contactDataService.ContactList.FirstOrDefault(c => c.Id == id);
            _contactDataService.ContactList.Remove(contactToDelete);
        }
    }
}
