using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Torneio.App.Interfaces;
using Torneio.Domain.Interfaces.Services;

namespace Torneio.App
{
    public class GenericAppService<T> : IGenericAppService<T> where T : class
    {
        private readonly IGenericService<T> _genericService;

        public GenericAppService(IGenericService<T> genericService)
        {
            _genericService = genericService;
        }

        public void Delete(object id)
        {
            _genericService.Delete(id);
        }

        public void Delete(T entityToDelete)
        {
            _genericService.Delete(entityToDelete);
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
           return  _genericService.Get(filter);
        }

        public IEnumerable<T> GetAll()
        {
            return _genericService.GetAll();
        }

        public T GetByID(int id)
        {
            return _genericService.GetByID(id);
        }

        public void Insert(T model)
        {
            _genericService.Insert(model);
        }

        public void Update(T entityToUpdate)
        {
            _genericService.Update(entityToUpdate);
        }

        public void Update(Expression<Func<T, bool>> filter, IEnumerable<object> updatedSet, IEnumerable<object> availableSet, string propertyName)
        {
            _genericService.Update(filter, updatedSet, availableSet, propertyName);
        }
    }
}
