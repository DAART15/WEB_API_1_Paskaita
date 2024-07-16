using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WEB_API_1_Paskaita.Controllers.Data.Dto;
using WEB_API_1_Paskaita.Interfaces;
using WEB_API_1_Paskaita.Models;

namespace WEB_API_1_Paskaita.DataBase.Configuratons
{
    public class SafetyCarConfiguration : IEntityTypeConfiguration<SafetyCar>
    {
        

        public void Configure(EntityTypeBuilder<SafetyCar> builder)
        {
            builder.ToTable("SafetyCars");
            builder.HasKey(sc => sc.Id);
            builder.Property(sc => sc.Id)
                .IsRequired()
                .ValueGeneratedNever();
            builder.Property(sc => sc.Brand)
                .IsRequired();
            builder.Property(sc => sc.Model)
                .IsRequired();
            builder.Property(sc => sc.Color)
                .IsRequired();


            builder.HasData(
            new SafetyCar(1, "Aston Martin", "Vantage", "Green Metalic"),
            new SafetyCar(2, "Mercedes-Benz", "AMG GT Black Series", "Black"),
            new SafetyCar(3, "Mercedes-Benz", "AMG GT R", "Silver"),
            new SafetyCar(4, "Lamborghini", "Diablo", "Red")
            );
            
        }
    }
}
