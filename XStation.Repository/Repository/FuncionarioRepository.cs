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
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly DataContext dataContext;
        public FuncionarioRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public Funcionario GetByCpf(string cpf)
        {
            return dataContext.Funcionario.FirstOrDefault( c => c.Cpf.Equals(cpf));
        }

        public void Insert(Funcionario obj)
        {
            dataContext.Funcionario.Add(obj);
            dataContext.SaveChanges();
        }

        public void Update(Funcionario obj)
        {
            dataContext.Entry(obj).State = EntityState.Modified;
            dataContext.SaveChanges();
        }

        public void Excluir(Funcionario obj)
        {
            dataContext.Funcionario.Remove(obj);
            dataContext.SaveChanges();
        }

        public List<Funcionario> GetAll()
        {
            return dataContext.Funcionario.OrderByDescending(p => p.DataCriacao).ToList();
        }

        public Funcionario GetById(int id)
        {
            return dataContext.Funcionario.Find(id);
        }

        public Funcionario GetByEmail(string email)
        {
            return dataContext.Funcionario.FirstOrDefault(u => u.Email.Equals(email));
        }


        public Funcionario GetByEmailandSenha(string email, string senha)
        {
            return dataContext.Funcionario.FirstOrDefault(u => u.Email.Equals(email) && u.Senha.Equals(senha));
        }
    }
}
