using REST_API_för_CV_hantering.Data;
using REST_API_för_CV_hantering.Endpoints;
using Microsoft.EntityFrameworkCore;

namespace REST_API_för_CV_hantering
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<CVContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();


            GithubEndpoints.RegisterEndpoints(app);
            EducationEndpoints.RegisterEndpoints(app);
            ExperienceEndpoints.RegisterEndpoints(app); 
            PersonEndpoints.RegisterEndpoints(app);

            app.Run();
        }
    }
}
