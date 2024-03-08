using Microsoft.Extensions.Options;
using Tranier_System.Repository;
using Tranier_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Tranier_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(Options =>
            {
                Options.IdleTimeout=TimeSpan.FromMinutes(35);
            });

            builder.Services.AddDbContext<TContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DB"));
            });

            builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
            builder.Services.AddScoped<ITraineeRepository, TraineeRepository>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<ICrsResultRepository, CrsResultRepository>();

            
            var app = builder.Build();
            //midd
            //app.Use(async (HttpContext, next) =>
            //{
            //    await HttpContext.Response.WriteAsync("first");

            //    await next.Invoke();
            //});
            //app.Run(async (HttpContext) =>
            //{
            //    await HttpContext.Response.WriteAsync("Termenite");

            //});
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
