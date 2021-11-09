using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace XStation.Repository.Entities
{
    public class Perfil
    {
        [Key]
        public int IdPerfil { get; set; }
        public string Nome { get; set; }
        

        #region Relacionamento

        public List<Funcionario> Funcionarios { get; set; }
        public List<Cliente> Clientes { get; set; }

        #endregion
    }
}
