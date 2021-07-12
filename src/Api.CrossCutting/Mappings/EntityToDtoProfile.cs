using System.Linq;
using Api.Domain.Dtos.Ator;
using Api.Domain.Dtos.Categoria;
using Api.Domain.Dtos.Filme;
using Api.Domain.Dtos.Idioma;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {

            CreateMap<FilmeDto, FilmeEntity>()
                .ReverseMap();
            
            CreateMap<AtorDto, AtorEntity>()
                .ReverseMap();
            
            CreateMap<CategoriaDto, CategoriaEntity>()
                .ReverseMap();
            
            CreateMap<IdiomaDto, IdiomaEntity>()
                .ReverseMap();

            CreateMap<FilmeEntity, FilmeDtoCompleto>()
                .ReverseMap();

            CreateMap<FilmeEntity, FilmeDtoCreate>()
                .ReverseMap();

            CreateMap<FilmeEntity, FilmeDtoUpdate>()
                .ReverseMap();

            CreateMap<AtorEntity, AtorDtoCompleto>()
                .ReverseMap();

            CreateMap<AtorEntity, AtorDtoCreate>()
                .ReverseMap();

            CreateMap<AtorEntity, AtorDtoUpdate>()
                .ReverseMap();

            CreateMap<IdiomaEntity, IdiomaDtoCompleto>()
                .ReverseMap();

            CreateMap<IdiomaEntity, IdiomaDtoCreate>()
                .ReverseMap();

            CreateMap<IdiomaEntity, IdiomaDtoUpdate>()
                .ReverseMap();
            
            CreateMap<CategoriaEntity, CategoriaDtoCompleto>()
                .ReverseMap();

            CreateMap<CategoriaEntity, CategoriaDtoCreate>()
                .ReverseMap();

            CreateMap<CategoriaEntity, CategoriaDtoUpdate>()
                .ReverseMap();
            
            
            //Isso é necessário para o mapper entender como mapear IEnumerable<FilmeAtorEntity> para IEnumerable<AtorDto>
            // CreateMap<FilmeAtorEntity, AtorDto>()
            //     .IncludeMembers(s => s.Ator).ReverseMap();

            // CreateMap<FilmeEntity, FilmeDtoCreateUpdate>()
            //     .ForMember(dest => dest.Atores, opt => {
            //         opt.MapFrom(src => src.FilmesAtores.Select(fa => fa.Ator).ToList());
            // });

            // CreateMap<FilmeDtoCreateUpdate, FilmeEntity>()
            //     .ForMember(dest => dest.FilmesAtores, opt => {
            //         opt.MapFrom(src => src.Atores.ToList());
            // });
            
            // //Não sei pq o ReverseMap não funciona para relacionamentos Many to Many!
            // //Preciso fazer os dois Maps, um para cada lado.
            // CreateMap<FilmeEntity, FilmeDtoCompleto>()
            //     .ForMember(
            //     dest => dest.Atores, opt => {
            //     opt.MapFrom(src => src.FilmesAtores.Select(fa => fa.Ator).ToList());
            // });


            // CreateMap<FilmeDtoCompleto, FilmeEntity>()
            //     .ForMember(
            //     dest => dest.FilmesAtores, opt => {
            //     opt.MapFrom(src => src.Atores.ToList());
            // });
        }
    }
}