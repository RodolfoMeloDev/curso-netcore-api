using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Seeds
{
    public static class UfSeeds
    {
        public static void UFs(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UfEntity>().HasData(
                new UfEntity()
                {
                    Id = Guid.NewGuid(),
                    Sigla = "AC",
                    Nome = "Acre",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity()
                {
                    Id = Guid.NewGuid(),
                    Sigla = "AL",
                    Nome = "Alagoas",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity()
                {
                    Id = Guid.NewGuid(),
                    Sigla = "AP",
                    Nome = "Amap�",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity()
                {
                    Id = Guid.NewGuid(),
                    Sigla = "AM",
                    Nome = "Amazonas",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity()
                {
                    Id = Guid.NewGuid(),
                    Sigla = "BA",
                    Nome = "Bahia",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity()
                {
                    Id = Guid.NewGuid(),
                    Sigla = "CE",
                    Nome = "Ceara",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity()
                {
                    Id = Guid.NewGuid(),
                    Sigla = "DF",
                    Nome = "Distrito Federal",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity()
                {
                    Id = Guid.NewGuid(),
                    Sigla = "ES",
                    Nome = "Esp�rito Santo",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity()
                {
                    Id = Guid.NewGuid(),
                    Sigla = "GO",
                    Nome = "Goi�s",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity()
                {
                    Id = Guid.NewGuid(),
                    Sigla = "MA",
                    Nome = "Maranh�o",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity()
                {
                    Id = Guid.NewGuid(),
                    Sigla = "MT",
                    Nome = "Mato Grosso",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity()
                {
                    Id = Guid.NewGuid(),
                    Sigla = "MS",
                    Nome = "Mato Grosso do Sul",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity()
                {
                    Id = Guid.NewGuid(),
                    Sigla = "MG",
                    Nome = "Minas Gerais",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity()
                {
                    Id = Guid.NewGuid(),
                    Sigla = "PA",
                    Nome = "Par�",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity()
                {
                    Id = Guid.NewGuid(),
                    Sigla = "PB",
                    Nome = "Para�ba",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity()
                {
                    Id = Guid.NewGuid(),
                    Sigla = "PR",
                    Nome = "Paran�",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity()
                {
                    Id = Guid.NewGuid(),
                    Sigla = "PE",
                    Nome = "Pernambuco",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity()
                {
                    Id = Guid.NewGuid(),
                    Sigla = "PI",
                    Nome = "Piau�",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity()
                {
                    Id = Guid.NewGuid(),
                    Sigla = "RJ",
                    Nome = "Rio de Janeiro",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity()
                {
                    Id = Guid.NewGuid(),
                    Sigla = "RN",
                    Nome = "Rio Grande do Norte",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity()
                {
                    Id = Guid.NewGuid(),
                    Sigla = "RS",
                    Nome = "Rio Grande do Sul",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity()
                {
                    Id = Guid.NewGuid(),
                    Sigla = "RO",
                    Nome = "Rond�nia",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity()
                {
                    Id = Guid.NewGuid(),
                    Sigla = "RR",
                    Nome = "Roraima",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity()
                {
                    Id = Guid.NewGuid(),
                    Sigla = "SC",
                    Nome = "Santa Catarina",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity()
                {
                    Id = Guid.NewGuid(),
                    Sigla = "SP",
                    Nome = "S�o Paulo",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity()
                {
                    Id = Guid.NewGuid(),
                    Sigla = "SE",
                    Nome = "Sergipe",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity()
                {
                    Id = Guid.NewGuid(),
                    Sigla = "TO",
                    Nome = "STocantins",
                    CreateAt = DateTime.UtcNow
                }
            );
        }
    }
}
