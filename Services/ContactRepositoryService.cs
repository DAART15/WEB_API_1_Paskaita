using Microsoft.EntityFrameworkCore;
using Web_Api.Domain.Models;
using Web_Api.Infrastructure.Interfaces;
using WEB_API_1_Paskaita.Interfaces;


namespace WEB_API_1_Paskaita.Services
{
    public class ContactRepositoryService(IContactRepository _contactRepository) : IContactRepositoryService
    {
        public async Task<IList<Contact>> GetALLContactsAsync()
        {
            return await _contactRepository.GetContactsFromDBAsync();
        }
        public async Task<Contact>GetContactByIdAsync(int id)
        {
            var allContacts = await GetALLContactsAsync();
            var contactById = allContacts.FirstOrDefault(x => x.Id == id);
            return contactById;
        }
        public async Task UpdateContactAsync(Contact contactToUpdate, Contact contact)
        {
            contactToUpdate.FirstName = contact.FirstName;
            contactToUpdate.LastName = contact.LastName;
            contactToUpdate.Company = contact.Company;
            contactToUpdate.PhoneNumber = contact.PhoneNumber;
            contactToUpdate.Mail = contact.Mail;
            contactToUpdate.Note = contact.Note;
            contactToUpdate.UpdatedAt = DateTime.Now;
            await _contactRepository.UpdateContactDBAsync(contactToUpdate);
        }
        public async Task CreateContactAsync(Contact contact)
        {
            var allContacts = await GetALLContactsAsync();
            int getLastContactId = allContacts.Max(c => c.Id);
            contact.Id = getLastContactId + 1;
            await _contactRepository.CreateContactDBAsync(contact);
        }
        public async Task DeleteContactAsync(Contact contactToDelete)
        {
            await _contactRepository.DeleteContactDBAsync(contactToDelete);
        }
    }
}
