using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheToDoListApp.Repository.Interfaces;
using TheToDoListApp.Service.DataTransferObjects;
using TheTodoRepository.Models;

namespace TheToDoListApp.Service.Interfaces
{
    public interface IToDoItemService : IGenericRepository<ToDoItemDto>
    {
        /// <summary>
        /// Get all completed TodoItems
        /// </summary>
        /// <returns></returns>
        Task<ObservableCollection<ToDoItemDto>> GetAllCompletedAsync();

        /// <summary>
        /// Get all uncompleted TodoItems
        /// </summary>
        /// <returns></returns>
        Task<ObservableCollection<ToDoItemDto>> GetAllUncompletedAsync();

        /// <summary>
        /// Get a TodoItem by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ToDoItemDto> GetByIDAsync(Guid id);
    }
}
