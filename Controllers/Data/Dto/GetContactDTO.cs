using System.ComponentModel.DataAnnotations;
using WEB_API_1_Paskaita.Models;

namespace WEB_API_1_Paskaita.Controllers.Data.Dto
{
    public class GetContactDTO(Contact contact)
    {
        public int Id { get; set; } = contact.Id;
        public string FirstName { get; set; } = contact.FirstName;
        public string LastName { get; set; } = contact.LastName;
        public string? Company { get; set; } = contact.Company;
        public string? PhoneNumber { get; set; } = contact.PhoneNumber;
        public string? Mail { get; set; } = contact.Mail;
        public string? Note { get; set; } = contact.Note;
    }
}
