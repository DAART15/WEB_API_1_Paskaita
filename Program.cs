using WEB_API_1_Paskaita.Controllers.Data.Dto;
using WEB_API_1_Paskaita.Interfaces;
using WEB_API_1_Paskaita.Services;

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
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<IFoodStoreService, FoodStoreService>();
            builder.Services.AddScoped<IFoodExpiryService, FoodExpiryService>();
            builder.Services.AddSingleton<IContactDataService, ContactDataService>();
            builder.Services.AddTransient<IContactUpdateService, ContactUpdateService>();
            builder.Services.AddSingleton<ISafetyCarDataService, SafetyCarDataService>();
            builder.Services.AddTransient<ISafetyCarService, SafetyCarService>();



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
