using WEB_API_1_Paskaita.DataBase;
using WEB_API_1_Paskaita.Models;

namespace WEB_API_1_Paskaita.Services.Repositories
{
    public interface IAccountRepository
    {
        void Add(Account account);
        Account Get(string username);
    }
    public class AccountRepository : IAccountRepository
    {
        private readonly AplicationDbContext _dbContext;

        public AccountRepository(AplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Account account)
        {
            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();
        }
        public Account Get(string username)
        {
            return _dbContext.Accounts.FirstOrDefault(x => x.Name == username);
        }
    }
}
