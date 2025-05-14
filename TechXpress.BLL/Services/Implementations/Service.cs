using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using TechXpress.BLL.Services.Contracts;
using TechXpress.Logic.Repository.Contracts;
using TechXpress.Logic.UnitOfWork;

namespace TechXpress.BLL.Services.Implementations
{
    public class Service<T, TKey> : IService<T, TKey> where T : class
    {
        private readonly IRepository<T, TKey> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<Service<T, TKey>> _logger;

        public Service(IRepository<T, TKey> repository, IUnitOfWork unitOfWork, ILogger<Service<T, TKey>> logger)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public bool Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                _repository.Add(entity);
                //_unitOfWork.CompleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding entity.");
                return false;
            }
        }

        public bool Delete(TKey id)
        {
            try
            {
                var entity = _repository.GetById(id);
                if (entity == null)
                    throw new KeyNotFoundException($"Entity with ID '{id}' not found.");

                _repository.Delete(id);
                //_unitOfWork.CompleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting entity with ID '{id}'.");
                return false;
            }
        }

        public List<T> GetAll()
        {
            try
            {
                return _repository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all entities.");
                return new List<T>();
            }
        }

        public T GetById(TKey id)
        {
            var entity = _repository.GetById(id);
            if (entity == null)
                throw new KeyNotFoundException($"Entity with ID '{id}' not found.");
            return entity;
        }

        public bool Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                _repository.Update(entity);
                //_unitOfWork.CompleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating entity.");
                return false;
            }
        }
    }
}
