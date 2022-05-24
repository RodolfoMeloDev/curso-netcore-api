using Api.Domain.Dtos.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserDto> GetUser(Guid id);
        Task<IEnumerable<UserDto>> GetUsers();
        Task<UserDtoCreateResult> Insert(UserDtoCreate user);
        Task<UserDtoUpdateResult> Update(UserDtoUpdate user);
        Task<bool> Delete(Guid id);
    }
}
