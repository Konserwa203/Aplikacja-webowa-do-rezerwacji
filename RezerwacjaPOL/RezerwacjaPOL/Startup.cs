using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RezerwacjaPOL.Models;
using RezerwacjaPOL.Models.Validators;
using RezerwacjaPOLLibrary.Context;
using RezerwacjaPOLLibrary.Models;
using RezerwacjaPOLLibrary.Settings;
using RezerwacjaPOLLibrary.Validators;
using RezerwacjaPOLLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nest;
using Elasticsearch.Net;

namespace RezerwacjaPOL
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
            services.AddControllersWithViews()
                .AddFluentValidation();

            services.AddDbContext<AuctionContext>(o => o.UseSqlServer(Configuration.GetConnectionString("dev")));
            services.AddTransient<IValidator<UserViewModel>, UserVMValidator>();
            services.AddTransient<IValidator<AuctionViewModel>, AuctionVMValidator>();
            services.AddTransient<IValidator<LoginViewModel>, LoginVMValidator>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(o =>
                {
                    o.LoginPath = "/Login/";
                }
                );


            services.AddSingleton<IGlobalSettings, GlobalSettings>();

            //elastic search stuff
            var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
            var settings = new ConnectionSettings(pool)
                .DefaultIndex("auctions");
            var client = new ElasticClient(settings);
            services.AddSingleton(client);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization(); 

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
