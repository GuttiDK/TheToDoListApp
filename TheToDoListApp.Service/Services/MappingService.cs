using AutoMapper;
using TheToDoListApp.Repository.Models;
using TheToDoListApp.Service.DataTransferObjects;

namespace TheToDoListApp.Service.Services
{
    public class MappingService
    {
        public readonly IMapper _mapper;


        public readonly MapperConfiguration _config = new(cfg =>
        {
            cfg.CreateMap<ToDoItem, ToDoItemDto>();
            cfg.CreateMap<ToDoItemDto, ToDoItem>();
        });

        public MappingService()
        {
            try
            {
                _mapper = _config.CreateMapper();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create map: " + ex.Message);
            }
        }
    }
}
