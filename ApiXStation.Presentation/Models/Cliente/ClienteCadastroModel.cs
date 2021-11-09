using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiXStation.Presentation.Models.Cliente
{
    public class ClienteCadastroModel
    {
        
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }        
        public DateTime DataNascimento { get; set; }
        public int IdPerfil { get; set; }
    }
}
