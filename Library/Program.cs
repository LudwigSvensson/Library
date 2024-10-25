
using Library.Data;
using Library.EndPoints;
using Library.Mapping;
using Library.Models;
using Library.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Library
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            //Cors
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Allow4200",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(MappingConfig));
            builder.Services.AddScoped<IBookRepository, BookRepository>();

            //DB
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionToDb")));

            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("Allow4200");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.ConfigurationBookEndPoints();

            app.Run();

            
        }
    }
}
