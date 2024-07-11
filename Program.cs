
using WEB_API_1_Paskaita.Controllers.Data;
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
