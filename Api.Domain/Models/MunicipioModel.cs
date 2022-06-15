using System;

namespace Api.Domain.Models
{
    public class MunicipioModel : BaseModel
    {
        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        private string _codIBGE;
        public string CodIBGE
        {
            get { return _codIBGE; }
            set { _codIBGE = value; }
        }

        private Guid _ufId;
        public Guid UfId
        {
            get { return _ufId; }
            set { _ufId = value; }
        }
    }
}
