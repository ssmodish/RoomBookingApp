using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using RoomBookingApp.Core.DataServices;
using RoomBookingApp.Core.Processors;
using RoomBookingApp.Persistence;
using RoomBookingApp.Persistence.Repositories;

namespace RoomBookingApp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var connectionString = "Data Source=:memory:";
            var connection = new SqliteConnection(connectionString);
            connection.Open();

            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            builder.Services.AddDbContext<RoomBookingAppDbContext>(opt => opt.UseSqlite(connection));

            builder.Services.AddScoped<IRoomBookingService, RoomBookingService>();
            builder.Services.AddScoped<IRoomBookingRequestProcessor, RoomBookingRequestProcessor>();

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
