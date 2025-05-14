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
    public class Repository<T, TKey> : IRepository<T, TKey> where T : class
    {
        private readonly AppDbContext _dbContext;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T GetById(TKey id)
        {
            return _dbContext.Find<T>(id);
        }

        public void Delete(TKey id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _dbContext.Remove(entity);
                _dbContext.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            if (entity != null)
            {
                _dbContext.Update(entity);
                _dbContext.SaveChanges();
            }
        }
    }

}
