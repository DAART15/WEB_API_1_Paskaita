using Web_Api.Domain.Models;
using WEB_API_1_Paskaita.Controllers.Data.Dto;


namespace WEB_API_1_Paskaita.Interfaces
{
    public interface IContactMapper
    {
        public GetContactDTO DateLess(Contact contact);
    }
}
