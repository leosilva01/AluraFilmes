using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Categoria;
using Api.Domain.Dtos.FilmeCategoria;
using Api.Domain.Entities;
using Api.Domain.Interface;
using Api.Domain.Interface.Services.Categoria;
using Api.Domain.Repository;
using AutoMapper;

namespace Api.Service.Services.Categoria
{
    public class CategoriaService : ICategoriaService
    {

        private ICategoriaRepository _repository;
        private IMapper _mapper;
        private readonly IUnitOfWork _uow;


        public CategoriaService(ICategoriaRepository repository, IMapper mapper, IUnitOfWork uow)
        {
            _repository = repository;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<bool> Delete(int id)
        {
            try{
                await _repository.DeleteAsync(id);
                return await _uow.Commit();
            } catch {
                await _uow.Rollback();
                return false;
            }
        }

        public async Task<CategoriaDto> Get(int id)
        {
            var entity = await _repository.SelectAsync(id);

            return _mapper.Map<CategoriaDto>(entity);
        }

        public async Task<IEnumerable<CategoriaDto>> GetAll()
        {
            var entity = await _repository.SelectAsync();

            return _mapper.Map<IEnumerable<CategoriaDto>>(entity);
        }

        public async Task<CategoriaDtoCompleto> GetCompleto(int id)
        {
            var entity = await _repository.GetCompleteById(id);

            var categoriaCompleto = _mapper.Map<CategoriaDtoCompleto>(entity);

            return categoriaCompleto;
        }

        public async Task<CategoriaDto> Post(CategoriaDtoCreate categoria)
        {
            try{
                var entity = _mapper.Map<CategoriaEntity>(categoria);

                var salvo = await _repository.InsertAsync(entity);

                await _uow.Commit();
                
                return _mapper.Map<CategoriaDto>(salvo);

            }catch(Exception ex){
                await _uow.Rollback();
                throw ex;
            }
        }

        public async Task<CategoriaDto> Put(int id, CategoriaDtoUpdate categoria)
        {
            var entity = _mapper.Map<CategoriaEntity>(categoria);

            try{

                var salvo = await _repository.UpdateAsync(id, entity);
                
                await _uow.Commit();

                return _mapper.Map<CategoriaDto>(salvo);

            }catch(Exception ex){
                await _uow.Rollback();

                throw ex;
            }
        }

        public async Task<CategoriaDto> AdicionarFilmeCategoria(FilmeCategoriaDto filmeCategoria)
        {
            try{
                var adicionado = await _repository.AdicionarFilmeCategoria(filmeCategoria);

                await _uow.Commit();

                return _mapper.Map<CategoriaDto>(adicionado);
            }catch(Exception ex){
                await _uow.Rollback();
                
                throw ex;
            }
        }

        public async Task<CategoriaDto> RemoverFilmeCategoria(FilmeCategoriaDto filmeCategoria)
        {
            try{
                var removido = await _repository.RemoverFilmeCategoria(filmeCategoria);

                await _uow.Commit();

                return _mapper.Map<CategoriaDto>(removido);
            }catch(Exception ex){
                await _uow.Rollback();
                throw ex;
            }
        }
    }
}