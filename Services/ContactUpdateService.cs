using WEB_API_1_Paskaita.Interfaces;

namespace WEB_API_1_Paskaita.Services
{
    public class ContactUpdateService : IContactUpdateService
    { 
        private readonly IContactDataService _contactDataService;

        public ContactUpdateService(IContactDataService contactDataService)
        {
            _contactDataService = contactDataService;
        }
        public void ChangeContactUpdateDateTime(int id)
        {
            var contactToChangeDateTime = _contactDataService.ContactList.FirstOrDefault(i => i.Id == id);
            contactToChangeDateTime.UpdatedAt = DateTime.Now;
        }
    }
}
