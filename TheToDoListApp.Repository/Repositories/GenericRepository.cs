using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using TheToDoListApp.Repository.Domain;
using TheToDoListApp.Repository.Interfaces;

namespace TheToDoListApp.Repository.Repositories
{
    public class GenericRepository<E> : IGenericRepository<E> where E : class
    {
        private readonly ToDoListContext _dbContext;

        public GenericRepository(ToDoListContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(E entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(E entity)
        {
            var dbEntity = await _dbContext.Set<E>().FindAsync(GetKey(entity));
            if (dbEntity != null)
            {
                _dbContext.Entry(dbEntity).CurrentValues.SetValues(entity);
            }
            else
            {
                _dbContext.Set<E>().Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
            }
            await _dbContext.SaveChangesAsync();
        }


        public async Task DeleteAsync(E entity)
        {
            var key = GetKey(entity);
            var trackedEntity = await _dbContext.Set<E>().FindAsync(key);

            if (trackedEntity != null)
            {
                _dbContext.Set<E>().Remove(trackedEntity);
            }
            else
            {
                _dbContext.Set<E>().Attach(entity);
                _dbContext.Set<E>().Remove(entity);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task<ObservableCollection<E>> GetAllAsync()
        {
            ObservableCollection<E> temp = new(await _dbContext.Set<E>().AsNoTracking().ToListAsync());
            return temp;
        }

        private object GetKey(E entity) =>
            // Example for Guid Id property
            entity.GetType().GetProperty("Id")?.GetValue(entity, null);

    }
}
