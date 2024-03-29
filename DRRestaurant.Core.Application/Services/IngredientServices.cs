using AutoMapper;
using DRRestaurant.Core.Application.Interfaces.Repositories;
using DRRestaurant.Core.Application.Interfaces.Services;
using DRRestaurant.Core.Application.ViewModels.Ingredient;
using DRRestaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRestaurant.Core.Application.Services
{
    public class IngredientServices : GenericServices<SaveIngredientVM, IngredientVM, Ingredient>, IIngredientServices
    {
        private readonly IIngredientRepository _repository;
        private readonly IMapper _mapper;

        public IngredientServices(IIngredientRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
