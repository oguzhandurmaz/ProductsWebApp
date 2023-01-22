using AutoMapper;
using ProductService.Dtos;
using ProductService.Models;

namespace ProductService.Profiles
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category,CategoryReadDto>();
            CreateMap<CategoryCreateDto,Category>();
        }
    }
}
