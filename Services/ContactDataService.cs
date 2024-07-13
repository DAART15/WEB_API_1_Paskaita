using WEB_API_1_Paskaita.Interfaces;
using WEB_API_1_Paskaita.Models;
namespace WEB_API_1_Paskaita.Services
{
    public class ContactDataService : IContactDataService
    {
        public List<Contact> ContactList { get; set; } = new List<Contact>()
        {
            new Contact(1, "Ramas", "Darr", "DAART15", "+37023456789", "ramas@daart15.com", "mano kontaktas"),
            new Contact(2, "Tadas", "Tadulis", "UAB Tadilis", "+370234", "tadas@tadulis.com", ""),
            new Contact(3, "Andius", "Daar", "DAART15", "+37023456799", "andriusl@daart15.com", "vyr. kontaktas"),
            new Contact(4, "Arma", "Daar", "DAART15", "+37023456788", "arma@daart15.com", "junior kontaktas"),
            new Contact(5, "Daiva", "Darr", "DAART15", "+3702345639", "daiva@daart15.com", "paciausias kontaktas"),
        };
    }
}
