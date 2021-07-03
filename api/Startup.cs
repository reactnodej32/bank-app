using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace bankapp
{
    public class Startup
    {


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {

            // FOR DOCKER TO DETECT MYSQL
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
            }));

            services.AddControllersWithViews();
            var host = Configuration["DATABASE_HOST"] ?? "localhost";
            var password = Configuration["MYSQL_ROOT_PASSWORD"] ?? "dbuserpassword";
            var userid = Configuration["MYSQL_USER"] ?? "dbuser";


            string connString = $"server={host};port=3306;userid={userid};password={password};database=users_prod;";
            // Console.WriteLine(connString);

            services.AddDbContext<BankDb>(
            option => option.UseMySql(connString, ServerVersion.AutoDetect(connString)
            )
        );





        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, BankDb db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                // app.UseHsts();
            }
            db.Database.EnsureCreated();
            // FOR DOCKER TO DETECT MYSQL
            app.UseCors("MyPolicy");
            // ALLOW EVERYTHING TO BE PROXIED
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }

}
