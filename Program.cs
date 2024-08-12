using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WEB_API_1_Paskaita.Controllers.Data.Dto;
using WEB_API_1_Paskaita.Interfaces;

using WEB_API_1_Paskaita.Services;

using Web_Api.Domain.Extebsions;
using Web_Api.Infrastructure.Extebsions;

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
            builder.Services.AddCors(p => p.AddPolicy("ProductionCorsPolicy", builder =>
            {
                builder.WithOrigins("https://www.google.com")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
            }));
            builder.Services.AddControllers();

            
            

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
                });
            });

            var jwtSettings = builder.Configuration.GetSection("Jwt");
            var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"]
                };
            });
            builder.Services.AddHttpClient();

            builder.Services.AddSingleton<IFoodStoreService, FoodStoreService>();
            builder.Services.AddSingleton<IJwtService, JwtService>();
            builder.Services.AddScoped<IFoodExpiryService, FoodExpiryService>();
            builder.Services.AddSingleton<IContactDataService, ContactDataService>();// neberikes kai updatepakursiu jau irepositoryservice, nes i DB viskas sukeliavo
            builder.Services.AddTransient<IContactUpdateService, ContactUpdateService>();
            builder.Services.AddScoped<ISafetyCarService, SafetyCarService>();
            
            
            builder.Services.AddScoped<IFoodMaper, FoodMaper>();
            
            builder.Services.AddScoped<IContactRepositoryService, ContactRepositoryService>();
            builder.Services.AddScoped<IContactMapper, ContactMapper>();
            
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddBusnesSevice();
            builder.Services.AddDatabaseServices(builder.Configuration.GetConnectionString("DefaultConection"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseCors("corsfordevelopment");
            }
            else
            {
                app.UseCors("ProductionCorsPolicy");
            }

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
