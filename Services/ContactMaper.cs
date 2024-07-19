using WEB_API_1_Paskaita.Controllers.Data.Dto;
using WEB_API_1_Paskaita.Interfaces;
using WEB_API_1_Paskaita.Models;

namespace WEB_API_1_Paskaita.Services
{
    public class ContactMaper : IContactMaper
    {
        public GetContactDTO DateLess(Contact contact)
        {
            return new GetContactDTO(contact);
        }
    }
}
