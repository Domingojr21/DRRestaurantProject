using AutoMapper;
using DRRestaurant.Core.Application.Interfaces.Repositories;
using DRRestaurant.Core.Application.Interfaces.Services;
using DRRestaurant.Core.Application.ViewModels.DishIngredients;
using DRRestaurant.Core.Domain.Entities;

namespace DRRestaurant.Core.Application.Services
{
    public class DishIngredienteServices : GenericServices<SaveDishIngredientsVM,DishIngredientsVM, DishIngredients>, IDishIngredientServices
    {
        private readonly IDishIngredientRepository _dishIngredientRepository;
        private readonly IMapper _mapper;

        public DishIngredienteServices(IDishIngredientRepository dishIngredientRepository, IMapper mapper) :base (dishIngredientRepository, mapper)
        {
            _dishIngredientRepository = dishIngredientRepository;
            _mapper = mapper;
        }

        public void DeleteByDishId(int DishId)
        {
           _dishIngredientRepository.DeleteByDishId(DishId);
        }

        public async Task<List<string>> GetIngredientsByDishId(int DishId)
        {
            var list = await _dishIngredientRepository.GetAllWithInclude(new List<string> { "Dish", "Ingredient" });
            List<string> dishIngredients = new();
            list = list.Where(x => x.DishId == DishId).ToList();

            foreach (var dish in list)
            {
                string ingredient = dish.Ingredient.Name;
                dishIngredients.Add(ingredient);
            }

            return dishIngredients;
        }
    }
}
