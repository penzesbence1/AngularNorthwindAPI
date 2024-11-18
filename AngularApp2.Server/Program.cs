using Microsoft.EntityFrameworkCore;
using NorthwindAPI_beadando.Models;

namespace NorthwindAPI_beadando
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Add DbContext with PostgreSQL connection
            builder.Services.AddDbContext<NorthwindContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("NorthwindConnect"))
            );

            // Add CORS policy to allow all origins
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin() // Allows any origin (frontend domain)
                           .AllowAnyMethod()  // Allows any HTTP method (GET, POST, etc.)
                           .AllowAnyHeader(); // Allows any header (for example, content-type)
                });
            });

            // Add Swagger/OpenAPI support (for development)
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            // Apply the CORS policy
            app.UseCors("AllowAll");
            // Enable HTTPS redirection
            app.UseHttpsRedirection();

            // Enable authorization (if necessary for other routes)
            app.UseAuthorization();

            

            // Map the controller routes
            app.MapControllers();

            // Run the application
            app.Run();
        }
    }
}
