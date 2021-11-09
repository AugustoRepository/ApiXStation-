using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace XStation.Repository.Entities
{
    public class Endereco
    {
        [Key]
        public int IdEndereco { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int IdCliente { get; set; }
        public int IdFuncionario { get; set; }

        #region Relacionamento

        public Funcionario Funcionario { get; set; }
        public Cliente Cliente { get; set; }

        #endregion
    }
}
