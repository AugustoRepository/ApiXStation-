using System;
using System.Collections.Generic;
using System.Text;
using XStation.Repository.Entities;

namespace XStation.Repository.Contracts
{
    public interface IEnderecoRepository 
    {
        void Insert(Endereco endereco);
        void Update(Endereco endereco);
        void Delete(Endereco endereco);

        List<Endereco> GetAllCliente(int idCliente);
        List<Endereco> GetAllFuncionario(int idFuncionario);
        Endereco GetByIdCliente(int idEndereco, int idCliente);
        Endereco GetByIdFuncionario(int idEndereco, int idFuncionario);
        
    }
}
