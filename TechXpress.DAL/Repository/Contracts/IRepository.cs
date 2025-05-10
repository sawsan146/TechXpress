using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress.Logic.Repository.Contracts
{
    public interface IRepository<T> where T : class
    {
         public List<T> GetAll();

        public T GetById(int id);

        public void Add(T entity);

        public void Update(T entity);

        public void Delete(int id);

    //    public bool DeleteAll();


    }
}
