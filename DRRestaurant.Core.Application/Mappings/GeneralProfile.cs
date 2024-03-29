using AutoMapper;
using DRRestaurant.Core.Application.ViewModels.Dish;
using DRRestaurant.Core.Application.ViewModels.DishCategory;
using DRRestaurant.Core.Application.ViewModels.DishIngredients;
using DRRestaurant.Core.Application.ViewModels.Ingredient;
using DRRestaurant.Core.Application.ViewModels.Order;
using DRRestaurant.Core.Application.ViewModels.OrderDishes;
using DRRestaurant.Core.Application.ViewModels.Table;
using DRRestaurant.Core.Application.ViewModels.TableStatus;
using DRRestaurant.Core.Domain.Entities;

namespace DRRestaurant.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile() 
        {
            #region Ingredient

            CreateMap<SaveIngredientVM, Ingredient>()
                .ForMember(x => x.Status, opt => opt.Ignore())
                .ForMember(x => x.DishIngredients, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<IngredientVM, Ingredient>()
                .ForMember(x => x.Status, opt => opt.Ignore())
                .ForMember(x => x.DishIngredients, opt => opt.Ignore())
                .ReverseMap();

            #endregion

            #region Category 

            CreateMap<DishCategoryVM, DishCategory>()
                .ForMember(x => x.Dishes, opt => opt.Ignore())
                .ForMember(x => x.Status, opt => opt.Ignore())
                .ReverseMap();
            #endregion

            #region Dish

            CreateMap<SaveDishVM, Dish>()
                .ForMember(x => x.DishIngredients, opt => opt.Ignore())
                .ForMember(x => x.Status, opt => opt.Ignore())
                .ForMember(x => x.Category, opt => opt.Ignore())
                .ForMember(x => x.Orders, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(x => x.Ingredients, opt => opt.Ignore());

            CreateMap<SaveDishVM, DishVM>()
               .ForMember(x => x.Ingredients, opt => opt.Ignore())
                 .ForMember(x => x.Category, opt => opt.Ignore())
               .ReverseMap()
               .ForMember(x => x.Ingredients, opt => opt.Ignore());

            CreateMap<DishVM, Dish>()
               .ForMember(x => x.DishIngredients, opt => opt.Ignore())
               .ForMember(x => x.Status, opt => opt.Ignore())
               .ForMember(x => x.Category, opt => opt.Ignore())
               .ForMember(x => x.Orders, opt => opt.Ignore())
               .ReverseMap()
               .ForMember(x => x.Ingredients, opt => opt.Ignore());
            #endregion

            #region DishIngredient

            CreateMap<SaveDishIngredientsVM, DishIngredients>()
               .ForMember(x => x.Status, opt => opt.Ignore())
               .ForMember(x => x.Ingredient, opt => opt.Ignore())
               .ForMember(x => x.Dish, opt => opt.Ignore())
               .ReverseMap();


            #endregion

            #region  TableStatus

            CreateMap<TableStatusVM, TableStatus>()
                .ForMember(x => x.Status, opt => opt.Ignore())
                .ForMember(x => x.Tables, opt => opt.Ignore())
                .ReverseMap();

            #endregion

            #region Table

            CreateMap<TableVM, Table>()
                .ForMember(x => x.Status, opt => opt.Ignore())
                .ForMember(x => x.TableStatus, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<SaveTableVM, Table>()
                .ForMember(x => x.Status, opt => opt.Ignore())
                .ForMember(x => x.TableStatus, opt => opt.Ignore())
               .ReverseMap();

            #endregion

            #region Order

            CreateMap<SaveOrderVM, Order>()
                .ForMember(x => x.Status, opt => opt.Ignore())
                .ForMember(x => x.IsCompleted, opt => opt.Ignore())
                .ForMember(x => x.Dishes, opt => opt.Ignore())
                .ForMember(x => x.Table, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(x => x.DishesToSelectIds, opt => opt.Ignore());

            CreateMap<OrderVM, Order>()
               .ForMember(x => x.Status, opt => opt.Ignore())
               .ForMember(x => x.Dishes, opt => opt.Ignore())
               .ForMember(x => x.Table, opt => opt.Ignore())
               .ReverseMap()
               .ForMember(x => x.DishesSelected, opt => opt.Ignore());

            #endregion

            #region OrderDishes

            CreateMap<SaveOrderDishVM, OrdersDishes>()
                .ForMember(x => x.Status, opt => opt.Ignore())
                .ReverseMap();

            #endregion
        }

    }
}
