using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress.DAL.Repository.Contracts
{
    public interface IRepository<T, TKey> where T : class
    {
        List<T> GetAll();
        T GetById(TKey id);
        void Add(T entity);
        void Update(T entity);
        void Delete(TKey id);
    }

}
