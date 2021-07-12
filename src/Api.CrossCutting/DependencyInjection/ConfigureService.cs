using Api.Domain.Interface.Services.Ator;
using Api.Domain.Interface.Services.Categoria;
using Api.Domain.Interface.Services.Filme;
using Api.Domain.Interface.Services.Idioma;
using Api.Service.Services.Ator;
using Api.Service.Services.Categoria;
using Api.Service.Services.Filme;
using Api.Service.Services.Idioma;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService (IServiceCollection serviceCollection){
            serviceCollection.AddTransient<IFilmeService, FilmeService>();
            serviceCollection.AddTransient<IIdiomaService, IdiomaService>();
            serviceCollection.AddTransient<IAtorService, AtorService>();
            serviceCollection.AddTransient<ICategoriaService, CategoriaService>();
        }
    }
}