using System;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAPI.Constants;
using WebClient.Constants;
using WebDAL.Models;

namespace WebClient
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
            services.AddLogging();
            services.AddControllersWithViews()
                .AddJsonOptions((options) => options.JsonSerializerOptions.PropertyNameCaseInsensitive = false);
            
            services.Configure<CookiePolicyOptions>(options => {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Strict;
            });
            
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                    options.SlidingExpiration = true;
                    options.AccessDeniedPath = "/Forbidden/";
                });

            services.AddAuthorization();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseCookiePolicy();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            
            app.Use(async (context, next) =>
            {
                Console.WriteLine($"{DateTime.Now:HH:mm:fff} - Route '{context.Request.Path}'");
                await next.Invoke();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            // app.Use(async (context, next) =>
            // {
            //     if (context.Request.Path.Value == Endpoints.Login)
            //     {
            //         await next.Invoke();
            //         return;
            //     }
            //     
            //     if (!context.Request.Cookies.TryGetValue(CookieNames.Guest, out string accountJson))
            //     {
            //         Console.WriteLine("GuestCookie is empty.");
            //         context.Response.Redirect(Endpoints.Login);
            //         return;
            //     }
            //
            //     var cookieGuest = JsonSerializer.Deserialize<Account>(accountJson);
            //
            //     if (cookieGuest == null)
            //     {
            //         Console.WriteLine("Cannot parse Guest cookie.");
            //         context.Response.Redirect(Endpoints.Login);
            //         return;
            //     }
            //
            //     if (cookieGuest.token == null)
            //     {
            //         Console.WriteLine("Cookie guest token is empty.");
            //         context.Response.Redirect(Endpoints.Login);
            //         return;
            //     }
            //     
            //     var response = await Program.ApiClient.PostAsync(ApiEndpoints.GuestAuthenticate, JsonContent.Create(cookieGuest));
            //     
            //     if (!response.IsSuccessStatusCode)
            //     {
            //         Console.WriteLine("Cookie guest token not exist.");
            //         context.Response.Redirect(Endpoints.Login);
            //         return;
            //     }
            //     
            //     await next.Invoke();
            // });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}