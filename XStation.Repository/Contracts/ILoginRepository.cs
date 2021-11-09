using System;
using System.Collections.Generic;
using System.Text;
using XStation.Repository.Entities;

namespace XStation.Repository.Contracts
{
    public interface ILoginRepository : IBaseRepository<Perfil>
    {
        Perfil GetByIdAndSenha(string login, string senha);
    }
}
