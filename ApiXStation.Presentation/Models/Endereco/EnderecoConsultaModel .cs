using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiXStation.Presentation.Models.Endereco
{
    public class EnderecoConsultaModel
    {
        public int Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int IdCliente { get; set; }
        public int IdFuncionario { get; set; }
    }
}
