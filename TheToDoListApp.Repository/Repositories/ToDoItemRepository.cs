using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheToDoListApp.Repository.Domain;
using TheToDoListApp.Repository.Interfaces;
using TheToDoListApp.Repository.Models;

namespace TheToDoListApp.Repository.Repositories
{
    public class ToDoItemRepository : GenericRepository<ToDoItem>, IToDoItemRepository
    {
        private readonly ToDoListContext _dbContext;

        public ToDoItemRepository(ToDoListContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ObservableCollection<ToDoItem>> GetAllCompletedAsync()
        {
            ObservableCollection<ToDoItem> temp = new(await _dbContext.ToDoItems.Where(x => x.IsCompleted == true).AsNoTracking().ToListAsync());
            return temp;
        }

        public async Task<ObservableCollection<ToDoItem>> GetAllUncompletedAsync()
        {
            ObservableCollection<ToDoItem> temp = new(await _dbContext.ToDoItems.Where(x => x.IsCompleted == false).AsNoTracking().ToListAsync());
            return temp;
        }

        public async Task<ToDoItem> GetByIDAsync(Guid id)
        {
            return await _dbContext.ToDoItems.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
