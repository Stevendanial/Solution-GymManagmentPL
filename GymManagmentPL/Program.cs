using GymManagmentBLL;
using GymManagmentBLL.Services.Classes;
using GymManagmentBLL.Services.Interface;
using GymManagmentBLL.ViewModels.AnalyticsViewModels;
using GymManagmentDAL.Data.Context;
using GymManagmentDAL.Repository.Classes;
using GymManagmentDAL.Repository.Interfaces;

//using GymManagmentDAL.Repository.Classes;
//using GymManagmentDAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GymManagmentPL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<GymDBContext>(Options=>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));


            }
                );
            builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
            builder.Services.AddAutoMapper(x=>x.AddProfile(new MappingProfile()));
            builder.Services.AddScoped<IAnalyticsService,AnalyticsService>();
            builder.Services.AddScoped<IMemberService,MemberService>();
            builder.Services.AddScoped<ITrainerService,TrainerService>();
            builder.Services.AddScoped<IPlanService,PlanService>();
            builder.Services.AddScoped<ISessionService,SessionService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
