using WEB_API_1_Paskaita.Models;

namespace WEB_API_1_Paskaita.Interfaces
{
    public interface IContactRepository
    {
        public Task<IList<Contact>> GetContactsFromDBAsync();
        public Task UpdateContactDBAsync(Contact contact);
        public Task CreateContactDBAsync(Contact contact);
        public Task DeleteContactDBAsync(Contact contact);
    }
}
