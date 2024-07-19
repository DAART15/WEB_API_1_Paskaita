using Microsoft.EntityFrameworkCore;
using WEB_API_1_Paskaita.DataBase;
using WEB_API_1_Paskaita.Interfaces;
using WEB_API_1_Paskaita.Models;

namespace WEB_API_1_Paskaita.Services.Repositories
{
    public class ContactRepository(AplicationDbContext _dbContext) : IContactRepository
    {
        public async Task<IList<Contact>> GetContactsFromDBAsync()
        {
            return await _dbContext.Contacts.ToListAsync();
        }
    }
}
