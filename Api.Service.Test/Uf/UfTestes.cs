using Api.Domain.Dtos.Uf;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Service.Test.Uf
{
    public class UfTestes
    {
        public static string Nome { get; set; }
        public static string  Sigla { get; set; }
        public static Guid IdUf { get; set; }

        public List<UfDto> listaUfDto  = new List<UfDto>();
        public UfDto UfDto;

        public UfTestes()
        {
            IdUf = Guid.NewGuid();
            Sigla = Faker.Address.UsState().Substring(1, 2);
            Nome = Faker.Address.UsState();

            for (int i = 0; i < 10; i++)
            {
                var dto = new UfDto
                {
                    Id = Guid.NewGuid(),
                    Sigla = Faker.Address.UsState().Substring(1, 2),
                    Nome = Faker.Address.UsState()
                };

                listaUfDto.Add(dto);                
            }

            UfDto = new UfDto
            {
                Id = IdUf,
                Sigla = Sigla,
                Nome = Nome
            };
        }
    }
}
