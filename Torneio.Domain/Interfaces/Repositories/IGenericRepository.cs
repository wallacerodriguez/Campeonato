using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Torneio.Domain.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        T GetByID(int id);

        IEnumerable<T> GetAll();

        void Insert(T model);

        void Delete(object id);

        void Delete(T entityToDelete);

        void Update(T entityToUpdate);

        void Update(Expression<Func<T, bool>> filter,
            IEnumerable<object> updatedSet,
            IEnumerable<object> availableSet,
            string propertyName);
    }
}
