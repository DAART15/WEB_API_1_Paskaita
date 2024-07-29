
using Microsoft.EntityFrameworkCore;
using WEB_API_1_Paskaita.DataBase.Configuratons;
using WEB_API_1_Paskaita.Models;

namespace WEB_API_1_Paskaita.DataBase
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<SafetyCar> SafetyCars { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new SafetyCarConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
        }
    }
}
