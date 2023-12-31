﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NewWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewWeb
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
            services.AddMvc();
            services.AddControllersWithViews();

            services.AddDbContext<ContaxDBlogin>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DBConnect"));
            });



            services.AddDbContext<PlanningDBcontax>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DBConnect2"));
            });

            services.AddDbContext<CountaxInfoLogesticB>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DBConnect2"));
            });

            services.AddDbContext<ContaxTopCoat>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DBConnect2"));
            });


            services.AddDbContext<CountaxStatusCar>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DBConnect3"));
            });

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // زمان معتبر بودن سشن
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSession();
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
