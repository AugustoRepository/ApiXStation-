using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XStation.Repository.Context;
using XStation.Repository.Contracts;
using XStation.Repository.Entities;

namespace XStation.Repository.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly DataContext dataContext;
        public EnderecoRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public Endereco GetByCep(string cep)
        {
            return dataContext.Endereco.FirstOrDefault(c => c.Cep.Equals(cep));
        }

        public void Insert(Endereco endereco)
        {
            dataContext.Endereco.Add(endereco);
            dataContext.SaveChanges();
        }

        public void Update(Endereco endereco)
        {
            dataContext.Entry(endereco).State = EntityState.Modified;
            dataContext.SaveChanges();
        }

        public void Delete(Endereco endereco)
        {
            dataContext.Endereco.Remove(endereco);
            dataContext.SaveChanges();
        }

        public List<Endereco> GetAll()
        {
            return dataContext.Endereco.OrderByDescending(e => e.IdEndereco).ToList();
        }

        public Endereco GetById(int id)
        {
            return dataContext.Endereco.Find(id);
        }

        public List<Endereco> GetAllCliente(int idCliente)
        {
            return dataContext.Endereco.Where(e => e.IdCliente == idCliente).ToList();
        }

        public Endereco GetByIdCliente(int idEndereco, int idCliente)
        {
            return dataContext.Endereco
                .FirstOrDefault(e => e.IdEndereco == idEndereco 
                && e.IdEndereco == idCliente);
        }

        public Endereco GetByIdFuncionario(int idEndereco, int idFuncionario)
        {
            return dataContext.Endereco
                .FirstOrDefault(e => e.IdEndereco == idEndereco 
                && e.IdFuncionario == idFuncionario);
        }

        public List<Endereco> GetAllFuncionario(int idFuncionario)
        {
            return dataContext.Endereco.Where(t => t.IdFuncionario == idFuncionario).ToList();
        }
    }
}
