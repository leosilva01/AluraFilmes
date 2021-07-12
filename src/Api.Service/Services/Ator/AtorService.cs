using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Ator;
using Api.Domain.Entities;
using Api.Domain.Interface;
using Api.Domain.Interface.Services.Ator;
using Api.Domain.Repository;
using AutoMapper;

namespace Api.Service.Services.Ator
{
    public class AtorService : IAtorService
    {
        IAtorRepository _repository;
        private IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public AtorService(IAtorRepository repository, IMapper mapper, IUnitOfWork uow)
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

        public async Task<AtorDto> Get(int id)
        {
            var entity = await _repository.SelectAsync(id);

            return _mapper.Map<AtorDto>(entity);
        }

        public async Task<IEnumerable<AtorDto>> GetAll()
        {
             var entity = await _repository.SelectAsync();

            return _mapper.Map<IEnumerable<AtorDto>>(entity);
        }

        public async Task<AtorDtoCompleto> GetCompleto(int id)
        {
            var entity = await _repository.GetCompleteById(id);

            var atorCompleto = _mapper.Map<AtorDtoCompleto>(entity);

            return atorCompleto;
        }

        public async Task<IEnumerable<AtoresPorCategoriaResult>> PorCategoria(string categoria)
        {
            
            var entity = await _repository.GetPorCategoria(categoria);

            return entity;
        }

        public async Task<AtorDto> Post(AtorDtoCreate ator)
        {
            var entity = _mapper.Map<AtorEntity>(ator);

            try{

                var salvo = await _repository.InsertAsync(entity);

                await _uow.Commit();
                
                return _mapper.Map<AtorDto>(salvo);

            }catch(Exception ex){
                await _uow.Rollback();

                throw ex;
            }
        }

        public async Task<AtorDto> Put(int atorId, AtorDtoUpdate ator)
        {
            if(atorId != ator.Id)
                return null;
            
            var entity = _mapper.Map<AtorEntity>(ator);

            try{

                var atualizado = await _repository.UpdateAsync(atorId, entity);

                await _uow.Commit();

                return _mapper.Map<AtorDto>(atualizado);
            }catch(Exception ex){
                await _uow.Rollback();

                throw ex;
            }
            
        }

        public async Task<IEnumerable<Top5AtoresComMaisFilmesResult>> Top5()
        {
            var entity = await _repository.Top5Atores();

            return entity;
        }
    }
}