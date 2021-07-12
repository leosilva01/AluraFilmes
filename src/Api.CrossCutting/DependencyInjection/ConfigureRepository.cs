using System;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Data.Repository;
using Api.Data.UoW;
using Api.Domain.Interface;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection services){
            
            services.AddScoped(typeof (IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IFilmeRepository, FilmeImplementation>();
            services.AddScoped<IIdiomaRepository, IdiomaImplementation>();
            services.AddScoped<IAtorRepository, AtorImplementation>();
            services.AddScoped<ICategoriaRepository, CategoriaImplementation>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            if(Environment.GetEnvironmentVariable("DATABASE").ToLower() == "MYSQL".ToLower()){

                services.AddDbContext<MyContext>(
                    options => options.UseMySql(Environment.GetEnvironmentVariable("DB_CONNECTION"),
                                            new MySqlServerVersion(new Version(8,0,23))));
            }
        }
    }
}