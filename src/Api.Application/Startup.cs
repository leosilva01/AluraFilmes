using System;
using Api.CrossCutting.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;

namespace Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            _environment = environment;
        }

        public IConfiguration Configuration { get; }
        IWebHostEnvironment _environment { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            if(_environment.IsEnvironment("Testing"))
            {
                Environment.SetEnvironmentVariable("DB_CONNECTION", "Persist Security Info=True;Server=localhost;Port=3306;Database=dbAluraFilmesTSTIntegration;Uid=root;Pwd=mudar@123");
                Environment.SetEnvironmentVariable("DATABASE", "MYSQL");
            }

            ConfigureRepository.ConfigureDependenciesRepository(services);
            ConfigureService.ConfigureDependenciesService(services);

            // var config = new AutoMapper.MapperConfiguration(cfg =>
            // {
            //     cfg.AddProfile(new EntityToDtoProfile());
            // });

            // IMapper mapper = config.CreateMapper();
            // services.AddSingleton(mapper);


            // Reconhece o AutoMapper pela herança do profile.
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            //Opções para resolver erro de looping infinito nos relacionamentos e para converter os enums de int para o valor.
            services.AddControllers()
                    .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                    .AddNewtonsoftJson(x => x.SerializerSettings.Converters.Add(new StringEnumConverter()));
                
                
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Application", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Application v1");
                c.RoutePrefix = string.Empty;
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
