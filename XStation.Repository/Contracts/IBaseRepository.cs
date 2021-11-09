using System;
using System.Collections.Generic;
using System.Text;

namespace XStation.Repository.Contracts
{
    public interface IBaseRepository<T>
    {
        void Insert(T obj);
        void Update(T obj);
        void Excluir(T obj);

        List<T> GetAll();
        T GetById(int id);
    }
}
