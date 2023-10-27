using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheToDoListApp.Repository.Models;

namespace TheToDoListApp.Repository.Interfaces
{
    public interface IToDoItemRepository : IGenericRepository<ToDoItem>
    {
        /// <summary>
        /// Get all completed TodoItems
        /// </summary>
        /// <returns></returns>
        Task<ObservableCollection<ToDoItem>> GetAllCompletedAsync();

        /// <summary>
        /// Get all uncompleted TodoItems
        /// </summary>
        /// <returns></returns>
        Task<ObservableCollection<ToDoItem>> GetAllUncompletedAsync();

        /// <summary>
        /// Get a TodoItem by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ToDoItem> GetByIDAsync(Guid id);
    }
}
