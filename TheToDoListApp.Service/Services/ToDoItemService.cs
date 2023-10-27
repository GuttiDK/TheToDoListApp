using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheToDoListApp.Repository.Interfaces;
using TheToDoListApp.Repository.Models;
using TheToDoListApp.Service.DataTransferObjects;
using TheToDoListApp.Service.Interfaces;
using TheTodoRepository.Repositories;

namespace TheToDoListApp.Service.Services
{
    public class ToDoItemService : GenericService<ToDoItemDto, IToDoItemRepository, ToDoItem>, IToDoItemService
    {
        private readonly IToDoItemRepository _iToDoItemRepository;
        private readonly MappingService _mappingService;

        public ToDoItemService(MappingService mappingService, IToDoItemRepository iToDoItemRepository) : base(mappingService, iToDoItemRepository)
        {
            _mappingService = mappingService;
            _iToDoItemRepository = iToDoItemRepository;
        }

        public async Task<ObservableCollection<ToDoItemDto>> GetAllCompletedAsync()
        {
            ObservableCollection<ToDoItemDto> temp = new(_mappingService._mapper.Map<ObservableCollection<ToDoItemDto>>(await _iToDoItemRepository.GetAllCompletedAsync()));
            return temp;
        }

        public async Task<ObservableCollection<ToDoItemDto>> GetAllUncompletedAsync()
        {
            ObservableCollection<ToDoItemDto> temp = new(_mappingService._mapper.Map<ObservableCollection<ToDoItemDto>>(await _iToDoItemRepository.GetAllUncompletedAsync()));
            return temp;
        }

        public async Task<ToDoItemDto> GetByIDAsync(Guid id)
        {
            return _mappingService._mapper.Map<ToDoItemDto>(await _iToDoItemRepository.GetByIDAsync(id));
        }
    }
}
