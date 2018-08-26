using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Torneio.Domain.Interfaces.Repositories;
using Torneio.Domain.Interfaces.Services;

namespace Torneio.Domain.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;

        }

        public void Delete(object id)
        {
            _repository.Delete(id);
        }

        public void Delete(T entityToDelete)
        {
            _repository.Delete(entityToDelete);
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            return _repository.Get(filter);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetByID(int id)
        {
            return _repository.GetByID(id);
        }

        public void Insert(T model)
        {
            _repository.Insert(model);
        }

        public void Update(T entityToUpdate)
        {
            _repository.Update(entityToUpdate);
        }

        public void Update(Expression<Func<T, bool>> filter, IEnumerable<object> updatedSet, IEnumerable<object> availableSet, string propertyName)
        {
            _repository.Update(filter, updatedSet, availableSet, propertyName);
        }
    }
}
