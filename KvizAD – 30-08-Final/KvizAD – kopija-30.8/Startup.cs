using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using KvizAD.DbModels;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using KvizAD.Services;
using KvizAD.Repositories;
using Newtonsoft;


namespace KvizAD
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private void SetupDbContext(IServiceCollection service)
        {
            var connString = Configuration.GetConnectionString("MyConnection");
            service.AddDbContext<KvizAnaDContext>(options => options.UseSqlServer(connString));

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           // services.AddControllersWithViews()
           // .AddNewtonsoftJson(options =>
            // options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            //ervices.AddMvc().AddNewtonsoftJson();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllersWithViews();
            services.AddScoped<KvizAnaDContext>();
            services.AddScoped<AdminRepository>();
            services.AddScoped<AdminServices>();
            services.AddScoped<LogRepository>();
            services.AddScoped<LogServices>();
            services.AddDbContext<KvizAnaDContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MyConnection")));
            SetupDbContext(services);

            // ovdje postavljamo koliko ce trajati svaka sesija. Kad istekne vrijeme sesija se brise
            // kad je sesija obrisana onda ako idemo npr. brisati pitanje morat cemo se ponovo ulogirati preko Admin Sign In
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromSeconds(3600);
            });
        }
        //ispod se nalaze 2 klase koje zapravo provjeravaju sesije. Pozivaju se direktno kod kontrolera prije akcije
        // ako je sesija prazna (ili ne odgovara klasi) onda vraca nazad na forme za login
        public class SessionUserTimeout : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                if (context.HttpContext.Session == null || !context.HttpContext.Session.TryGetValue("SessionUser", out byte[] val))
                {
                    context.Result =
                        new RedirectToRouteResult(new RouteValueDictionary(new
                        {
                            controller = "Home",
                            action = "Index"
                        }));
                }
                base.OnActionExecuting(context);
            }
        }

        public class SessionAdminTimeout : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                if (context.HttpContext.Session == null || !context.HttpContext.Session.TryGetValue("SessionAdmin", out byte[] val))
                {
                    context.Result =
                        new RedirectToRouteResult(new RouteValueDictionary(new
                        {
                            controller = "Authentication",
                            action = "AdminLogIn"
                        }));
                }
                base.OnActionExecuting(context);
            }
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            

            app.UseAuthorization();

            // za autentifikaciju:
            app.UseAuthentication();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   "Pitanja",
                   "KvizAnaD/pitanja",
                   new { controller = "Pitanja", action = "Pitanja" }
                   );

                endpoints.MapControllerRoute(
                    "User",
                    "user/pitanja",
                    new { controller = "User", action = "Index" }
                         );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");


                endpoints.MapControllerRoute("Registracija", "Registracija", 
                    new { controller = "Authentication", action = "Registracija" });

                endpoints.MapControllerRoute("Authentication", "Authentication",
                    new { controller = "Authentication", action = "Authentication" });

                endpoints.MapControllerRoute("AdminLogIn", "AdminLogIn", 
                    new { controller = "Authentication", action = "AdminLogIn" });
                endpoints.MapControllerRoute(
                    "TheEnd",
                    "TheEnd/Win",
                    new { controller = "TheEnd", action = "Win" }
                         );


                endpoints.MapControllerRoute("Defeat", "Defeat",
                    new { controller = "TheEnd", action = "Defeat" });
            });

        }
    }
}
