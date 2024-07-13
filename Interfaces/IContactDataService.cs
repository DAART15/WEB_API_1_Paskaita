using WEB_API_1_Paskaita.Models;

namespace WEB_API_1_Paskaita.Interfaces
{
    public interface IContactDataService
    {
        public List<Contact> ContactList { get; set; }
    }
}
