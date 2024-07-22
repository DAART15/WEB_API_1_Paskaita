using Microsoft.EntityFrameworkCore;
using WEB_API_1_Paskaita.Interfaces;
using WEB_API_1_Paskaita.Models;

namespace WEB_API_1_Paskaita.Services
{
    public class ContactRepositoryService(IContactRepository _contactRepository) : IContactRepositoryService
    {
        public async Task<IList<Contact>> GetALLContactsAsync()
        {
            return await _contactRepository.GetContactsFromDBAsync();
        }
        /*public async Task<bool> CheckContactId(int id)
        {
            var allContacts = await GetALLContactsAsync();
            allContacts.Find(x => x.Id == id);
            
        }*/
        public async Task<Contact>GetContactById(int id)
        {
            var allContacts = await GetALLContactsAsync();
            var contactById = allContacts.FirstOrDefault(x => x.Id == id);
            return contactById;
        }
    }
    
}
