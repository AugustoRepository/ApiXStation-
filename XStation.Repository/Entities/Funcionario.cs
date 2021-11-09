using System;
using System.Collections.Generic;
using System.Text;
using XStation.Repository.Enuns;

namespace XStation.Repository.Entities
{
    public class Funcionario
    {
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string  Telefone1{ get; set; }
        public string  Telefone2{ get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataNascimento { get; set; }

        #region Relacionamento
        public int IdEndereco { get; set; }

        public int IdPerfil { get; set; }
        public Perfil Perfil { get; set; }
        
        public List<Endereco> Enderecos { get; set; }
        #endregion
    }
}
