using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.DAL.Infrastructure;
using TechXpress.Logic.Repository.Contracts;

namespace TechXpress.Logic.Repository.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;
        public Repository(AppDbContext dbContext)
        { 
            _dbContext = dbContext;
        }
        public void Add(T entity)
        {
            _dbContext.Add<T>(entity);
            _dbContext.SaveChanges();

        }

        public List<T> GetAll()
        {
            var list = _dbContext.Set<T>().ToList();
            return list;
        }
        public T GetById(int id)
        {
            var e=_dbContext.Find<T>(id);
            return e;
        }

        public void Delete(int id)
        {

            var e=GetById(id);

            if (e != null)
            {
                _dbContext.Remove(e);       
                _dbContext.SaveChanges();
            }

        }

        //public bool DeleteAll()
        //{

        //}

        //public List<T> GetAll()
        //{
        //    var list = _dbContext

        //}
   
        public void Update(T entity)
        {
            if (entity != null)
            {
                _dbContext.Update<T>(entity);
                _dbContext.SaveChanges();
            }
        }

    }
}
