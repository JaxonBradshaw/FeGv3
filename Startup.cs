using FeGv3.Data;
using FeGv3.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeGv3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(Configuration.GetConnectionString("FagElGamousConnection"));
            // Server = fagelgamous.chzsky3lb73g.us - east - 1.rds.amazonaws.com,1433; Database = FagElGamous; User Id = admin; Password = f4g3lg4m0us;
            builder.UserID = Configuration["DbUser"];
            builder.Password = Configuration["DbPassword"];
            builder.InitialCatalog = "FagElGamous";
            builder.MultipleActiveResultSets = true;
            builder.DataSource = "fagelgamous.chzsky3lb73g.us-east-1.rds.amazonaws.com";

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.ConnectionString));
            services.AddDbContext<FagElGamousContext>(options => options.UseSqlServer(builder.ConnectionString));

            //services.AddDbContext<FagElGamousContext>(options => options.UseSqlServer(Configuration.GetConnectionString("FagElGamous")));
            //services.AddDbContext<ApplicationDbContext>(options =>
            //options.UseSqlServer(
            //    Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDbContext<FagElGamousContext>(options =>
            //{
            //  options.UseSqlServer(Configuration["ConnectionStrings:FagElGamousConnection"]);
            //});


            services.AddControllersWithViews();
            services.AddRazorPages();

            // services need for sessions
            services.AddDistributedMemoryCache();
            services.AddSession();

            //to get the current user
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();

            // added for admin functionality
            services.AddServerSideBlazor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
