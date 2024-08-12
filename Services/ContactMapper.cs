using Web_Api.Domain.Models;
using WEB_API_1_Paskaita.Controllers.Data.Dto;
using WEB_API_1_Paskaita.Interfaces;


namespace WEB_API_1_Paskaita.Services
{
    public class ContactMapper : IContactMapper
    {
        public GetContactDTO DateLess(Contact contact)
        {
            return new GetContactDTO(contact);
        }
    }
}
