using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Torneio.Domain.Interfaces.Repositories;
using Torneio.Infra.Data.Context;

namespace Torneio.Infra.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal BaseContext context;
        internal DbSet<T> dbSet;

        public GenericRepository(BaseContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public void Delete(object id)
        {
            T entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public void Delete(T entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T GetByID(int id)
        {
            return dbSet.Find(id);
        }

        public void Insert(T model)
        {
            dbSet.Add(model);
        }

        public void Update(T entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;

        }

        public void Update(Expression<Func<T, bool>> filter, IEnumerable<object> updatedSet, IEnumerable<object> availableSet, string propertyName)
        {
            // Obter o tipo genérico que sera alterado
            var type = updatedSet.GetType().GetGenericArguments()[0];

            // Obtem a entidade anterior do banco de dados com base no tipo de repositório
            var previous = context
                .Set<T>()
                .Include(propertyName)
                .FirstOrDefault(filter);

            /* Crie um conteiner que mantenha os valores do
                * relacionamento many-to-many genéricos que estamos atualizando.
                */
            var values = CreateList(type);
            var name = updatedSet.First().GetType().ToString();
            name = name.Split('.').Last();
            /* Para cada objeto no conjunto atualizado, encontre a
                 * entidade no banco de dados. Isso é para evitar o Entity Framework
                 * de criar novos objetos ou lançar um
                 * erro porque o objeto já está conectado.
                 */
            foreach (var entry in updatedSet
                .Select(obj => (int)obj
                    .GetType()
                    .GetProperty(name + "Id")
                    .GetValue(obj, null))
                .Select(value => context.Set(type).Find(value)))
            {
                values.Add(entry);
            }

            /* Obter a coleção onde os relacionamentos many-to-many anteriores 
                * são armazenados e atribuem os novos.
                */
            context.Entry(previous).Collection(propertyName).CurrentValue = values;
        }

        public IList CreateList(Type type)
        {
            var genericList = typeof(List<>).MakeGenericType(type);
            return (IList)Activator.CreateInstance(genericList);
        }

       
    }
}
