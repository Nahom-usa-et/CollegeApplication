
using CollegeApplication.Data.DbContexts;
using CollegeApplication.Interfaces___Implimentaions.Interfaces;
using CollegeApplication.Logings.Implemet_ILog;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
namespace CollegeApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            
            builder.Services.AddControllers(options=>options.ReturnHttpNotAcceptable = true).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StudentDbContext>(Options =>
                {
                    Options.UseSqlServer(builder.Configuration.GetConnectionString("StudentdbConnectionstring"));
                });
            builder.Services.AddSingleton<ILog  , Logtofile>();
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
