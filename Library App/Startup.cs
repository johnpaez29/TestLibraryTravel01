using LibraryApp.Business.Handlers;
using LibraryApp.DataService.ModelsSql;
using LibraryApp.DataService.Repositories;
using LibraryApp.Model.DTO;
using LibraryApp.Model.Others;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_App
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
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddScoped<IRepository<Autore>, AuthorRepository>()
                .AddScoped<IRepository<Libro>, BookRepository>()
                .AddScoped<IRepository<Editoriale>, EditorialRepository>()
                .AddScoped<IHandler<Autore>, AuthorHandler>()
                .AddScoped<IHandlerBook<Libro, BookDto>, BookHandler>()
                .AddScoped<IHandler<Editoriale>, EditorialHandler>()
                .AddScoped<IRepository<AutoresLibro>, AuthorBookRepository>()

                .AddDbContext<LibreriaTravelContext>(
                    options =>
                    options.UseSqlServer(Configuration.GetConnectionString(Constants.ConnectionStringSql))
                );
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
