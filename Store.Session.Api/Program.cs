
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Store.Session.Core.Mapping;
using Store.Session.Core.Reposities.Contract;
using Store.Session.Repository.Data;
using Store.Session.Repository.Data.Context;
using Store.Session.Repository.Reposities;
using Store.Session.Service.Services.Products;

namespace Store.Session.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IProductService,ProductService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper(M => M.AddProfile( new ProductProfile()));



            var app = builder.Build();

           var scop=  app.Services.CreateScope();
            var service=   scop.ServiceProvider;
             var context=  service.GetRequiredService<AppDbContext>();
            var loggerFactory= service.GetRequiredService<ILoggerFactory>();
            try
            {
                await context.Database.MigrateAsync();
              await  StoreDbContextSeed.SeedASync(context);
            }
            catch(Exception ex) 
            {
                var logger=  loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "there are problems during apply migrations");
            }


            //AppDbContext context = new AppDbContext();
            //context.Database.MigrateAsync();

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
