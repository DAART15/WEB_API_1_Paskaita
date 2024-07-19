using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WEB_API_1_Paskaita.Models;

namespace WEB_API_1_Paskaita.DataBase.Configuratons
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedNever();
            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(c => c.Company)
                .HasMaxLength(500);
            builder.Property(c => c.PhoneNumber)
                .HasMaxLength (15);
            builder.Property(c => c.Mail)
                .HasMaxLength (100);
            builder.Property(c => c.Note)
                .HasMaxLength(8000);
            builder.Property(c => c.CreatedAt)
                .IsRequired()
                .ValueGeneratedNever();
            builder.Property(c => c.UpdatedAt)
                .IsRequired()
                .ValueGeneratedNever();

            builder.HasData(
                new Contact(1, "Ramas", "Darr", "DAART15", "+37023456789", "ramas@daart15.com", "mano kontaktas"),
                new Contact(2, "Tadas", "Tadulis", "UAB Tadilis", "+370234", "tadas@tadulis.com", ""),
                new Contact(3, "Andius", "Daar", "DAART15", "+37023456799", "andriusl@daart15.com", "vyr. kontaktas"),
                new Contact(4, "Arma", "Daar", "DAART15", "+37023456788", "arma@daart15.com", "junior kontaktas"),
                new Contact(5, "Daiva", "Darr", "DAART15", "+3702345639", "daiva@daart15.com", "paciausias kontaktas")
                );

        }
    }
}
