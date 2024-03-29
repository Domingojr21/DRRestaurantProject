using AutoMapper;
using DRRestaurant.Core.Application.Interfaces.Repositories;
using DRRestaurant.Core.Application.Interfaces.Services;
using DRRestaurant.Core.Application.ViewModels.Dish;
using DRRestaurant.Core.Application.ViewModels.DishIngredients;
using DRRestaurant.Core.Domain.Entities;
using System.Collections.Generic;

namespace DRRestaurant.Core.Application.Services
{
    public class DishServices : GenericServices<SaveDishVM, DishVM, Dish>, IDishServices
    {
        private readonly IDishRepository _dishRepository;
        private readonly IDishCategoryRepository _dishCategoryRepository;
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IDishIngredientServices _dishIngredientServices;
        private readonly IMapper _mapper;

        public DishServices(IDishRepository dishRepository, 
            IDishCategoryRepository dishCategoryRepository, 
            IIngredientRepository ingredientRepository,
            IDishIngredientServices dishIngredientServices,
            IMapper mapper) : base(dishRepository, mapper)
            {
            _dishRepository = dishRepository;
            _dishCategoryRepository = dishCategoryRepository;
            _ingredientRepository = ingredientRepository;
            _dishIngredientServices = dishIngredientServices;
            _mapper = mapper;
        }

        public override async Task<SaveDishVM> Add(SaveDishVM vm)
        {
            var dishIngredients = vm.Ingredients;
            var ingredientList = await _ingredientRepository.GetAllAsync();
            var categoryList = await _dishCategoryRepository.GetAllAsync();

            bool categoryExist = categoryList.Exists(x => x.Id == vm.CategoryId);
            if (categoryExist)
            {
                vm = await base.Add(vm);
                foreach (var dishIngredient in dishIngredients)
                {
                    bool ingredientExists = ingredientList.Exists(x => x.Id == dishIngredient);
                    if (ingredientExists)
                    {
                        await _dishIngredientServices.Add(new SaveDishIngredientsVM
                        {
                            DishId = vm.Id,
                            IngredientId = dishIngredient
                        });
                    }
                }
            }else
            {
                return null;
            }

          
            return vm;
        }

        public override async Task Update(SaveDishVM vm, int id)
        {
            var dishIngredients = vm.Ingredients;
            _dishIngredientServices.DeleteByDishId(id);
            var ingredientList = await _ingredientRepository.GetAllAsync();
            var categoryList = await _dishCategoryRepository.GetAllAsync();
            

            bool categoryExist = categoryList.Exists(x => x.Id == vm.CategoryId);
            if (categoryExist)
            {
                vm.Id = id;
               await base.Update(vm, id);
            }

            foreach (var dishIngredient in dishIngredients)
            {

                bool ingredientExists = ingredientList.Exists(x => x.Id == dishIngredient);

                if (ingredientExists)
                {
                    await _dishIngredientServices.Add(new SaveDishIngredientsVM
                    {
                        DishId = vm.Id,
                        IngredientId = dishIngredient
                    });
                }
            }
        }


        public async Task<List<DishVM>> GetAllViewModelWithInclude()
        {
            var list = GetAllViewModel();

            var categoryList = await _dishCategoryRepository.GetAllAsync();

            foreach (var dish in await list)
            {
                dish.Category =  categoryList.Where(x => x.Id == dish.Id).Select(x => x.CategoryName).FirstOrDefault();
                dish.Ingredients = await _dishIngredientServices.GetIngredientsByDishId(dish.Id);
            }

            return await list;
        }


        public async Task<DishVM> GetByIdViewModel(int id)
        {
            SaveDishVM svm = await base.GetByIdSaveViewModel(id);

            if(svm != null)
            {
                DishVM vm = _mapper.Map<DishVM>(svm);

                var categoryList = await _dishCategoryRepository.GetAllAsync();

                vm.Category = categoryList.Where(x => x.Id == id).Select(x => x.CategoryName).FirstOrDefault();
                vm.Ingredients = await _dishIngredientServices.GetIngredientsByDishId(id);

                return vm;
            }

            return null;
        }

    }
}
