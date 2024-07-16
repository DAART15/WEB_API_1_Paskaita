using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WEB_API_1_Paskaita.Models;

namespace WEB_API_1_Paskaita.DataBase.Configuratons
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedNever();
            builder.Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(x => x.City)
                .HasMaxLength(100);

            builder.HasIndex(x => x.Id)
                .IsUnique();
            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.HasData(
            new User
            {
                Id = Guid.NewGuid(),
                UserName = "JohnDoe",
                Email = "johndoe@example.com",
                City = "New York"
            },
            new User
            {
                Id = Guid.NewGuid(),
                UserName = "JaneDoe",
                Email = "janedoe@example.com",
                City = "Los Angeles"
            }
            );
        }

    }
}
