using AutoMapper;
using DRRestaurant.Core.Application.Interfaces.Repositories;
using DRRestaurant.Core.Application.Interfaces.Services;
using DRRestaurant.Core.Application.ViewModels.DishCategory;
using DRRestaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRestaurant.Core.Application.Services
{
    public class DishCategoryServices : GenericServices<SaveDishCategoryVM, DishCategoryVM, DishCategory>, IDishCategoryServices
    {
        private readonly IDishCategoryRepository _repository;
        private readonly IMapper _mapper;

        public DishCategoryServices(IDishCategoryRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

    }
}
