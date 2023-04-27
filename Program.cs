using AmazingTeknikModels;
using Microsoft.EntityFrameworkCore;
using SUT22_AmaingTeknik.Models;
using SUT22_AmaingTeknik.Services;

namespace SUT22_AmaingTeknik
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddNewtonsoftJson
                (options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IAmazingTeknik<Product>, ProductRepsoitory>();
            builder.Services.AddScoped<IAmazingTeknik<Order>, OrderRepository>();

            // EF Till SQL 
            builder.Services.AddDbContext<AppDbContex>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}