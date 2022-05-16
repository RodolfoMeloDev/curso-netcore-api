using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserEntity> GetUser(Guid id);
        Task<IEnumerable<UserEntity>> GetUsers();
        Task<UserEntity> Insert(UserEntity user);
        Task<UserEntity> Update(UserEntity user);
        Task<bool> Delete(Guid id);
    }
}
