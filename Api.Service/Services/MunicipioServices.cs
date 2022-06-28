using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Municipio;
using Api.Domain.Models;
using Api.Domain.Repository;
using AutoMapper;

namespace Api.Service.Services
{
    public class MunicipioServices : IMunicipioService
    {
        private IMunicipioRepository _repository;
        private readonly IMapper _mapper;

        public MunicipioServices(IMunicipioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<MunicipioDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<MunicipioDto>(entity);
        }

        public async Task<IEnumerable<MunicipioDto>> GetAll()
        {
            var listaEntity = await _repository.SelectAllAsync();
            return _mapper.Map<IEnumerable<MunicipioDto>>(listaEntity);
        }

        public async Task<MunicipioDtoCompleto> GetByIBGE(int codIBGE)
        {
            var entity = await _repository.GetCompleteByIBGE(codIBGE);
            return _mapper.Map<MunicipioDtoCompleto>(entity);
        }

        public async Task<MunicipioDtoCompleto> GetById(Guid id)
        {
            var entity = await _repository.GetCompleteById(id);
            return _mapper.Map<MunicipioDtoCompleto>(entity);
        }

        public async Task<MunicipioDtoCreateResult> Post(MunicipioDtoCreate municipio)
        {
            var model = _mapper.Map<MunicipioModel>(municipio);
            var entity = _mapper.Map<MunicipioEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<MunicipioDtoCreateResult>(result);
        }

        public async Task<MunicipioDtoUpdateResult> Put(MunicipioDtoUpdate municipio)
        {
            var model = _mapper.Map<MunicipioModel>(municipio);
            var entity = _mapper.Map<MunicipioEntity>(model);
            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<MunicipioDtoUpdateResult>(result);
        }
    }
}
