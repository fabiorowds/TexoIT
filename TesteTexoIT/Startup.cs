using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using TesteTexoIT.Domain.Context;
using TestoTexoIT.Application.Services;

namespace TesteTexoIT
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();


            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Projeto - Desafio Texo IT", Version = "v1" }));

            services.AddDbContext<TexoContext>(x => x.UseSqlite(Configuration.GetConnectionString("SQLite")));
            services.AddScoped<AwardService>();
            services.AddScoped<ReadFileService>();
            services.AddScoped<SearchMinMaxService>();

            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ReadFileService readFileService, AwardService awardService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Desafio - Texo IT"));

            var awards = awardService.GetAll();
            if (awards.Count == 0)
            {
                using (var stream = File.OpenRead("movielist.csv"))
                {
                    readFileService.ReadFile(new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name)));
                }
            }
        }
    }
}
