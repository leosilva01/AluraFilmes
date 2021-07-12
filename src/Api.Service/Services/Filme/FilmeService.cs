using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Repository;
using Api.Domain.Dtos.Filme;
using Api.Domain.Dtos.FilmeAtor;
using Api.Domain.Entities;
using Api.Domain.Interface;
using Api.Domain.Interface.Services.Filme;
using AutoMapper;

namespace Api.Service.Services.Filme
{
    public class FilmeService : IFilmeService
    {
        private IFilmeRepository _repository;
        private IMapper _mapper;
        private readonly IUnitOfWork _uow;


        public FilmeService(IFilmeRepository repository, IMapper mapper, IUnitOfWork uow)
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

        public async Task<FilmeDto> Get(int id)
        {
            
            var entity = await _repository.SelectAsync(id);

            return _mapper.Map<FilmeDto>(entity);
        }

        public async Task<IEnumerable<FilmeDto>> GetAll()
        {
            var entity = await _repository.SelectAsync();

            return _mapper.Map<IEnumerable<FilmeDto>>(entity);
        }

        public async Task<FilmeDtoCompleto> GetCompleto(int id)
        {
            var entity = await _repository.GetCompleteById(id);

            var filmeCompleto = _mapper.Map<FilmeDtoCompleto>(entity);

            var x = _mapper.Map<FilmeEntity>(filmeCompleto);

            return filmeCompleto;
        }

        public async Task<FilmeDto> Post(FilmeDtoCreate filme)
        {
            
            var entity = _mapper.Map<FilmeEntity>(filme);

            var x = _mapper.Map<FilmeDtoCreate>(entity);

            try{

                var salvo = await _repository.InsertAsync(entity);
                
                await _uow.Commit();
                
                return _mapper.Map<FilmeDto>(salvo);

            }catch(Exception ex){
                await _uow.Rollback();
                throw ex;
            }
        }

        public async Task<FilmeDto> Put(int filmeId, FilmeDtoUpdate filme)
        {
            if(filmeId != filme.Id)
                return null;

            var entity = _mapper.Map<FilmeEntity>(filme);

            try{

                var atualizado = await _repository.UpdateAsync(filmeId, entity);

                await _uow.Commit();

                var retorno = _mapper.Map<FilmeDto>(atualizado);

                return retorno;

            } catch(Exception ex) {
                await _uow.Rollback();
                throw ex;
            }
        }

        public async Task<FilmeDtoCompleto> AdicionarAtorFilme(AddAtorFilmeDto atorFilme)
        {
            try{
                var adicionado = await _repository.AddAtorFilme(atorFilme);
                
                await _uow.Commit();

                return _mapper.Map<FilmeDtoCompleto>(adicionado);

            } catch(Exception ex) {
                await _uow.Rollback();
                throw ex;
            }
        }

        public async Task<FilmeDtoCompleto> RemoverAtorFilme(AddAtorFilmeDto atorFilme)
        {
            try{

            var removido = await _repository.RemoveAtorFilme(atorFilme);
            
            await _uow.Commit();
            
            return _mapper.Map<FilmeDtoCompleto>(removido);
            
            }catch(Exception ex){
                await _uow.Rollback();
                throw ex;
            }
        }
    }
}