using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieViewer.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieViewer.Service.Repository;
using MovieViewer.Models;
using MovieViewer.ApiClient;
using MovieViewer.Scheduler;
using MovieViewer.Service;

namespace MovieViewer
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


            // dependency injection
            services.AddScoped<MovieService>();
            services.AddScoped<MovieDbApiClient>();
            services.AddScoped<MovieRespository>();

            // shcedule task dependency injection
            services.AddSingleton<Microsoft.Extensions.Hosting.IHostedService, RetreiveDataScheduleTask>();


            // set up soical network authentication credentail
            // The secret was store in AWS server, if you want to test on local, please 
            // use your or ask for the secret
            SetEbConfig();
            services.AddAuthentication().AddMicrosoftAccount(microsoftOptions =>
            {
                microsoftOptions.ClientId = Environment.GetEnvironmentVariable("MicrosoftApplicationId");
                microsoftOptions.ClientSecret = Environment.GetEnvironmentVariable("MicrosoftPassword");
            })
            .AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = Environment.GetEnvironmentVariable("GoogleClientId");
                googleOptions.ClientSecret = Environment.GetEnvironmentVariable("GoogleClientSecret");
            })
            .AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Environment.GetEnvironmentVariable("FacebookAppId");
                facebookOptions.AppSecret = Environment.GetEnvironmentVariable("FacebookAppSecret");
            })
            .AddTwitter(twitterOptions => {
                twitterOptions.ConsumerKey = Environment.GetEnvironmentVariable("TwitterConsumerKey");
                twitterOptions.ConsumerSecret = Environment.GetEnvironmentVariable("TwitterConsumerSecret");
            })
            .AddCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login";
                options.LogoutPath = "/Identity/Account/Logout";
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();



            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        /// <summary>
        /// Retreive properties from AWS server and store to application environment
        /// </summary>
        private static void SetEbConfig()
        {
            var tempConfigBuilder = new ConfigurationBuilder();

            tempConfigBuilder.AddJsonFile(
                @"C:\Program Files\Amazon\ElasticBeanstalk\config\containerconfiguration",
                optional: true,
                reloadOnChange: true
            );

            var configuration = tempConfigBuilder.Build();

            var ebEnv =
                configuration.GetSection("iis:env")
                    .GetChildren()
                    .Select(pair => pair.Value.Split(new[] { '=' }, 2))
                    .ToDictionary(keypair => keypair[0], keypair => keypair[1]);

            foreach (var keyVal in ebEnv)
            {
                Environment.SetEnvironmentVariable(keyVal.Key, keyVal.Value);
            }
        }
    }
}
