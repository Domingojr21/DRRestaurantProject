using AutoMapper;
using DRRestaurant.Core.Application.Interfaces.Repositories;
using DRRestaurant.Core.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRestaurant.Core.Application.Services
{
    public class GenericServices<SVModel, VModel, Model> : IGenericService<SVModel, VModel, Model>
        where SVModel : class
        where VModel : class
        where Model : class

    {
        private readonly IGenericRepository<Model> _genericRepository;
        private readonly IMapper _mapper;

        public GenericServices(IGenericRepository<Model> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public virtual async Task<SVModel> Add(SVModel vm)
        {
            var entity = _mapper.Map<Model>(vm);

            await _genericRepository.AddAsync(entity);

            var entitySV = _mapper.Map<SVModel>(entity);

            return entitySV;
        }

        public virtual async Task Delete(int id)
        {
            var entity = await _genericRepository.GetByIdAsync(id);
            await _genericRepository.DeleteAsync(entity);
        }

        public virtual async Task<List<VModel>> GetAllViewModel()
        {
            var vmList = await _genericRepository.GetAllAsync();
            return _mapper.Map<List<VModel>>(vmList);
        }

        public virtual async Task<SVModel> GetByIdSaveViewModel(int id)
        {
            var entity = await _genericRepository.GetByIdAsync(id);
            return _mapper.Map<SVModel>(entity);
        }

        public virtual async Task Update(SVModel vm, int id)
        {
            Model entity = _mapper.Map<Model>(vm);

            await _genericRepository.UpdateAsync(entity, id);
        }
    }
}
