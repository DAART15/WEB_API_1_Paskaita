

using Web_Api.Domain.Models;

namespace WEB_API_1_Paskaita.Interfaces
{
    public interface IContactRepositoryService
    {
        public Task<IList<Contact>> GetALLContactsAsync();
        public Task<Contact> GetContactByIdAsync(int id);
        public Task UpdateContactAsync(Contact contactToUpdate, Contact contact);
        public Task CreateContactAsync(Contact contact);
        public Task DeleteContactAsync(Contact contactToDelete);
    }
}
