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
        public async Task UpdateContactDBAsync(Contact contact)
        {
            _dbContext.Contacts.Update(contact);
            await _dbContext.SaveChangesAsync();
        }
        public async Task CreateContactDBAsync(Contact contact)
        {
            _dbContext.Contacts.Add(contact);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteContactDBAsync(Contact contact)
        {
            _dbContext.Contacts.Remove(contact);
            await _dbContext.SaveChangesAsync();
        }
    }
}
