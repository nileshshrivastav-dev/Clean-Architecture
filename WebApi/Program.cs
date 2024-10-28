
using Microsoft.EntityFrameworkCore;
using WebApi.Application.Services;
using WebApi.Domain.Interface;
using WebApi.Infraustructure.Data;
using WebApi.Infraustructure.Repository;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<BlogDbContext>(options=>
            options.UseSqlServer(builder.Configuration.GetConnectionString("dbms")));

            builder.Services.AddTransient<IBlogRepository, BlogRepository>();
            builder.Services.AddTransient<IBlogService, BlogService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
