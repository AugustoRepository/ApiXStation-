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
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext dataContext;
        public ClienteRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public Cliente GetByCpf(string cpf)
        {
            return dataContext.Cliente.FirstOrDefault( c => c.Cpf.Equals(cpf));
        }

        public void Insert(Cliente obj)
        {
            dataContext.Cliente.Add(obj);
            dataContext.SaveChanges();
        }

        public void Update(Cliente obj)
        {
            dataContext.Entry(obj).State = EntityState.Modified;
            dataContext.SaveChanges();
        }

        public void Excluir(Cliente obj)
        {
            dataContext.Cliente.Remove(obj);
            dataContext.SaveChanges();
        }

        public List<Cliente> GetAll()
        {
            return dataContext.Cliente.OrderByDescending(p => p.DataCriacao).ToList();
        }

        public Cliente GetById(int id)
        {
            return dataContext.Cliente.Find(id);
        }

        public Cliente GetByEmail(string email)
        {
            return dataContext.Cliente.FirstOrDefault(u => u.Email.Equals(email));
        }

        public Cliente GetByEmailAndSenha(string email, string senha)
        {
            return dataContext.Cliente.FirstOrDefault(u => u.Email.Equals(email) && u.Senha.Equals(senha));
        }
    }
}
