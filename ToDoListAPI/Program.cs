
using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Mappings;
using ToDoListAPI.Models;
using ToDoListAPI.Services;

namespace ToDoListAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("ToDoListConnectionString");


            builder.Services.AddDbContext<ToDoListContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("ToDoListConnection")));

            builder.Services.AddDbContext<ToDoListContext>(options =>
            options.UseSqlServer(connectionString));

            builder.Services.AddAutoMapper(typeof(ToDoListProfile).Assembly);

            builder.Services.AddScoped<ToDoListService>();


            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();


            if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
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
