using WEB_API_1_Paskaita.Models;

namespace WEB_API_1_Paskaita.Interfaces
{
    public interface IContactRepositoryService
    {
        public Task<IList<Contact>> GetALLContactsAsync();
    }
}
