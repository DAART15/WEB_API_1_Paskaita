

using Web_Api.Domain.Models;

namespace WEB_API_1_Paskaita.Interfaces
{
    public interface IContactDataService
    {
        public List<Contact> ContactList { get; set; }
    }
}
