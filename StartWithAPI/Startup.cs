using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using StartWithAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartWithAPI
{
    public class Startup
    {
        // zeer belangrijke klasse!!

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StartWithAPI", Version = "v1" });
            });

            services.AddDbContext<AppContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString"));
            });

            services.AddTransient<IAppUserService, AppUserService>();
            //1) AddTransient (iedere keer oproepen, maar niet opslaan - garbagecollector gaat die iedere opruimen),
            //2) AddScope (meerdere gebruikers, elk hun eigen singelton) of
            //3) AddSingleton (1 gebruiker, één instantie ongeacht hoeveel gebruikers, garbagecollector gaat die NIET opruimen)
            // => allemaal methodes voor dependency injection!
            services.AddTransient<IAccountService, AccountService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StartWithAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
