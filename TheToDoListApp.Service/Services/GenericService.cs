using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheToDoListApp.Repository.Interfaces;
using TheToDoListApp.Service.Interfaces;

namespace TheToDoListApp.Service.Services
{
    public abstract class GenericService<Dto, IRepository, Entity> : IGenericService<Dto> where Dto : class where IRepository : IGenericRepository<Entity> where Entity : class
    {
        private readonly IRepository _genericRepository;
        private readonly MappingService _mappingService;

        #region Constructor
        protected GenericService(MappingService mappingService, IRepository genericRepository)
        {
            _mappingService = mappingService;
            _genericRepository = genericRepository;
        }
        #endregion

        public async Task CreateAsync(Dto entity)
        {
            await _genericRepository.CreateAsync(_mappingService._mapper.Map<Entity>(entity));
        }

        public async Task DeleteAsync(Dto entity)
        {
            await _genericRepository.DeleteAsync(_mappingService._mapper.Map<Entity>(entity));
        }

        public async Task<ObservableCollection<Dto>> GetAllAsync()
        {
            return _mappingService._mapper.Map<ObservableCollection<Dto>>(await _genericRepository.GetAllAsync());
        }

        public async Task UpdateAsync(Dto entity)
        {
            await _genericRepository.UpdateAsync(_mappingService._mapper.Map<Entity>(entity));
        }

    }
}
