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
        //public List<T> GetAll();

        public T GetById(int id);

        public bool Add(T entity);

        public bool Update(T entity);

        public bool Delete(int id);

    //    public bool DeleteAll();


    }
}
