using Microsoft.EntityFrameworkCore;
using WEB_API_1_Paskaita.Controllers.Data.Dto;
using WEB_API_1_Paskaita.DataBase;
using WEB_API_1_Paskaita.Interfaces;
using WEB_API_1_Paskaita.Models;
using WEB_API_1_Paskaita.Services;
using WEB_API_1_Paskaita.Services.Repositories;

namespace WEB_API_1_Paskaita
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            
            builder.Services.AddCors(p => p.AddPolicy("corsfordevelopment", builder =>
            {
                builder.WithOrigins("*")
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));
            builder.Services.AddControllers();

            builder.Services.AddDbContext<AplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConection"));
            });
            

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpClient();

            builder.Services.AddSingleton<IFoodStoreService, FoodStoreService>();
            builder.Services.AddScoped<IFoodExpiryService, FoodExpiryService>();
            builder.Services.AddSingleton<IContactDataService, ContactDataService>();// neberikes kai updatepakursiu jau irepositoryservice, nes i DB viskas sukeliavo
            builder.Services.AddTransient<IContactUpdateService, ContactUpdateService>();
            builder.Services.AddScoped<ISafetyCarService, SafetyCarService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ISafetyCarRepository, SafetyCarRepository>();
            builder.Services.AddScoped<IFoodMaper, FoodMaper>();
            builder.Services.AddScoped<IContactRepository, ContactRepository>();
            builder.Services.AddScoped<IContactRepositoryService, ContactRepositoryService>();
            builder.Services.AddScoped<IContactMaper, ContactMaper>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("corsfordevelopment");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
