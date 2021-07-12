using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Idioma;
using Api.Domain.Entities;
using Api.Domain.Interface.Services.Idioma;
using Api.Domain.Repository;
using AutoMapper;

namespace Api.Service.Services.Idioma
{
    public class IdiomaService : IIdiomaService
    {
        private IIdiomaRepository _repository;
        private IMapper _mapper;

        public IdiomaService(IIdiomaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IdiomaDto> Get(int id)
        {
            var entity = await _repository.SelectAsync(id);

            return _mapper.Map<IdiomaDto>(entity);
        }

        public async Task<IEnumerable<IdiomaDto>> GetAll()
        {
            var entity = await _repository.SelectAsync();

            return _mapper.Map<IEnumerable<IdiomaDto>>(entity);
        }

        public async Task<IdiomaDtoCompleto> GetCompleto(int id)
        {
            
            var entity = await _repository.GetCompleteById(id);

            var idiomaCompleto = _mapper.Map<IdiomaDtoCompleto>(entity);

            return idiomaCompleto;
        }

        public async Task<IdiomaDto> Post(IdiomaDtoCreate idioma)
        {
            
            var entity = _mapper.Map<IdiomaEntity>(idioma);

            try{

                var salvo = await _repository.InsertAsync(entity);
                
                return _mapper.Map<IdiomaDto>(salvo);

            }catch(Exception ex){
                throw ex;
            }
        }

        public async Task<IdiomaDto> Put(int id, IdiomaDtoUpdate idioma)
        {
            
            var entity = _mapper.Map<IdiomaEntity>(idioma);

            try{

                var salvo = await _repository.UpdateAsync(id, entity);
                
                return _mapper.Map<IdiomaDto>(salvo);

            }catch(Exception ex){
                throw ex;
            }
        }
    }
}