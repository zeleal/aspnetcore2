using System;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using ModeloRelacionamentos.Infra;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModeloRelacionamentos.Application.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using ModeloRelacionamentos.Application.Interfaces;

namespace ModeloRelacionamentos.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
               .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                builder.AddApplicationInsightsSettings(developerMode: true);
            }
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")))
                .AddUnitOfWork<ApplicationContext>(); ;

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IPessoaAppService, PessoaAppService>();

            services.AddSingleton(_ => Configuration);

            services.AddCors(o => o.AddPolicy("PolicyCors", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => {
                    //REDIRECIONANDO PARA A CONTROLER ABAIXO SE NÃO ESTIVER LOGADO
                    options.LoginPath = "/Login/Index/";
                    options.Cookie.Expiration = TimeSpan.FromMinutes(2);
                    //INFORMANDO UM CÓDIGO DE ERRO AO INVÉS DE REDIRECIONAR SE NÃO HOUVER AUTENTICAÇÃO
                    //options.Events.OnRedirectToLogin = (context) =>
                    //{
                    //    context.Response.StatusCode = 401;
                    //    return Task.CompletedTask;
                    //};
                });

            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors("PolicyCors");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();

                DbInitializer.Seed(app);
            }

            app.UseAuthentication();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
