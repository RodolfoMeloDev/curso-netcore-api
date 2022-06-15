using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Municipio
{
    public class MunicipioDtoCreate
    {
        [Required(ErrorMessage = "Nome do Munic�pio � campo obrigat�rio")]
        [StringLength(60, ErrorMessage = "Nome do Munic�pio deve ter no m�ximo {1} caracteres")]
        public string Nome { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "C�digo do IBGE inv�lido")]
        public int CodIBGE { get; set; }

        [Required(ErrorMessage = "C�digo de UF � campo obrigat�rio")]
        public Guid UfId { get; set; }
    }
}
