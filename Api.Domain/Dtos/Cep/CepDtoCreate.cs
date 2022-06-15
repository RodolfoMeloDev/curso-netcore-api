using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Cep
{
    public class CepDtoCreate
    {
        [Required(ErrorMessage = "CEP � campo obrigat�rio")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Logradouro � campo obrigat�rio")]
        public string Logradouro { get; set; }

        public string Numero { get; set; }

        [Required(ErrorMessage = "Municip�o � campo obrigat�rio")]
        public Guid MunicipioId { get; set; }
    }
}
