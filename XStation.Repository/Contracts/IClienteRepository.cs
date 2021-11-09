using System;
using System.Collections.Generic;
using System.Text;
using XStation.Repository.Entities;

namespace XStation.Repository.Contracts
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Cliente GetByCpf(string cpf);
        Cliente GetByEmail(string email);
        Cliente GetByEmailAndSenha(string email, string senha);
    }
}
