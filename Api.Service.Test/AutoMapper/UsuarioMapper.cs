using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class UsuarioMapper : BaseTesteService
    {
        [Fact(DisplayName = "É possível mapear os Mdelos")]
        public void E_Possivel_Mapear_os_Modelos()
        {
            var model = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var listaEntity = new List<UserEntity>();
            for (int i =0; i < 5; i++)
            {
                var item = new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };

                listaEntity.Add(item);
            }

            //Model => Entity
            var dtoToEntity = Mapper.Map<UserEntity>(model);
            Assert.Equal(dtoToEntity.Id, model.Id);
            Assert.Equal(dtoToEntity.Name, model.Name);
            Assert.Equal(dtoToEntity.Email, model.Email);
            Assert.Equal(dtoToEntity.CreateAt, model.CreateAt);
            Assert.Equal(dtoToEntity.UpdateAt, model.UpdateAt);

            //Entity => Dto
            var userDto = Mapper.Map<UserDto>(dtoToEntity);
            Assert.Equal(userDto.Id, dtoToEntity.Id);
            Assert.Equal(userDto.Name, dtoToEntity.Name);
            Assert.Equal(userDto.Email, dtoToEntity.Email);
            Assert.Equal(userDto.CreateAt, dtoToEntity.CreateAt);

            var listaDto = Mapper.Map<List<UserDto>>(listaEntity);
            Assert.True(listaDto.Count() == listaEntity.Count());

            for (int i = 0; i < listaDto.Count(); i++)
            {
                Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listaDto[i].Name, listaEntity[i].Name);
                Assert.Equal(listaDto[i].Email, listaEntity[i].Email);
                Assert.Equal(listaDto[i].CreateAt, listaEntity[i].CreateAt);
            }

            var userDtoCreateResult = Mapper.Map<UserDtoCreateResult>(dtoToEntity);
            Assert.Equal(userDtoCreateResult.Id, dtoToEntity.Id);
            Assert.Equal(userDtoCreateResult.Name, dtoToEntity.Name);
            Assert.Equal(userDtoCreateResult.Email, dtoToEntity.Email);
            Assert.Equal(userDtoCreateResult.CreateAt, dtoToEntity.CreateAt);

            var userDtoUpdateResult = Mapper.Map<UserDtoUpdateResult>(dtoToEntity);
            Assert.Equal(userDtoUpdateResult.Id, dtoToEntity.Id);
            Assert.Equal(userDtoUpdateResult.Name, dtoToEntity.Name);
            Assert.Equal(userDtoUpdateResult.Email, dtoToEntity.Email);
            Assert.Equal(userDtoUpdateResult.UpdateAt, dtoToEntity.UpdateAt);

            // Dto => Model
            var userModel = Mapper.Map<UserModel>(userDto);
            Assert.Equal(userModel.Id, userDto.Id);
            Assert.Equal(userModel.Name, userDto.Name);
            Assert.Equal(userModel.Email, userDto.Email);
            Assert.Equal(userModel.CreateAt, userDto.CreateAt);

            var userDtoCreate = Mapper.Map<UserDtoCreate>(userModel);
            Assert.Equal(userDtoCreate.Name, userModel.Name);
            Assert.Equal(userDtoCreate.Email, userModel.Email);

            var userDtoUpdate = Mapper.Map<UserDtoUpdate>(userModel);
            Assert.Equal(userDtoUpdate.Id, userModel.Id);
            Assert.Equal(userDtoUpdate.Name, userModel.Name);
            Assert.Equal(userDtoUpdate.Email, userModel.Email);
        }
    }
}
