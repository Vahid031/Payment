using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Http;
using Web.Middlewares;
using Web.Interfaces;
using Web.Concretes;
using Domain.Context;

namespace Web
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
            services.AddControllersWithViews();

            services.AddDbContext<AppDbContext>(options =>
       options.UseSqlServer(Configuration.GetConnectionString("DbConnectionString")));

            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationFormats.Clear();
                options.ViewLocationFormats.Add("/Areas/Views/{1}/{0}" + RazorViewEngine.ViewExtension);
                options.ViewLocationFormats.Add("/Areas/Views/Shared/{0}" + RazorViewEngine.ViewExtension);
            });

            services.AddRazorPages();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo
            //    {
            //        Version = "v1",
            //        Title = "Online Payment",
            //        Description = "Swagger UI for SAP Online Payment",
            //        TermsOfService = new Uri("http://saapp.ir/"),
            //        //Contact = new OpenApiContact
            //        //{
            //        //    Name = "Shayne Boyer",
            //        //    Email = string.Empty,
            //        //    Url = new Uri("https://twitter.com/spboyer"),
            //        //},
            //        //License = new OpenApiLicense
            //        //{
            //        //    Name = "Use under LICX",
            //        //    Url = new Uri("https://example.com/license"),
            //        //}
            //    });
            //}
            //);



            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAppDbContext, AppDbContext>();
            services.AddScoped<IPaymentService, PaymentService>();
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
                app.UseMiddleware<ErrorHandlerMiddleware>();
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
                //context.Database.Migrate();
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();
            }

            app.UseStaticFiles();

           

            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SAP Online Payment");
            //});

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Payment}/{action=Index}/{id?}");
            });


        }
    }
}
