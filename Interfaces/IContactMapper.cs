using WEB_API_1_Paskaita.Controllers.Data.Dto;
using WEB_API_1_Paskaita.Models;

namespace WEB_API_1_Paskaita.Interfaces
{
    public interface IContactMapper
    {
        public GetContactDTO DateLess(Contact contact);
    }
}
