using System;
using System.Collections.Generic;
using System.Text;
using XStation.Repository.Entities;

namespace XStation.Repository.Contracts
{
    public interface IFuncionarioRepository : IBaseRepository<Funcionario>
    {
        Funcionario GetByCpf(string cpf);
        Funcionario GetByEmail(string email);
        Funcionario GetByEmailandSenha(string email, string senha);
    }
}
