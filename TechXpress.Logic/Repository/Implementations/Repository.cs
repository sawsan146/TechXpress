using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Logic.Repository.Contracts;

namespace TechXpress.Logic.Repository.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        public Repository(DbContext dbContext)
        { 
            _dbContext = dbContext;
        }
        public bool Add(T entity)
        {
            _dbContext.Add<T>(entity);
            int res = _dbContext.SaveChanges();

            return res > 0;

        }

        public T GetById(int id)
        {
            var e=_dbContext.Find<T>(id);

            return e;
        }

        public bool Delete(int id)
        {

            var e=GetById(id);

            if (e != null)
            {
                _dbContext.Remove(e);       
                return true;
            }

            return false;

        }

        //public bool DeleteAll()
        //{

        //}

        //public List<T> GetAll()
        //{
        //    var list = _dbContext

        //}
   
        public bool Update(T entity)
        {
            if (entity != null)
            {
                _dbContext.Update<T>(entity);
                return true;
            }

            return false;
        }

    }
}
