using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Municipio;

namespace Api.Domain.Interfaces.Services.Municipio
{
    public interface IMunicipioService
    {
        Task<MunicipioDto> Get(Guid id);
        Task<IEnumerable<MunicipioDtoCompleto>> GetById(Guid id);
        Task<IEnumerable<MunicipioDtoCompleto>> GetByIBGE(int codIBGE);
        Task<IEnumerable<MunicipioDto>> GetAll(int codIBGE);
        Task<MunicipioDtoCreateResult> Post(MunicipioDtoCreate municipio);
        Task<MunicipioDtoUpdateResult> Put(MunicipioDtoUpdate municipio);
        Task<bool> Delete(Guid id);
    }
}
