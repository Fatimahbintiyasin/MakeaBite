using AutoMapper;
using MakeaBite_WebAPI.DTOs;
using MakeaBite_Library.Models;

namespace MakeaBite_WebAPI.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            CreateMap<Recipe, RecipeDto>();
            CreateMap<Recipe, RecipeWithoutIdDto>();
            CreateMap<Ingredient, IngredientDto>();
            CreateMap<IngredientWithoutIdDto, Ingredient>();
        }
    }
}
 