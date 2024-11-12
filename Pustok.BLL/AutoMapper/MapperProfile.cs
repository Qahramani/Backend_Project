using Pustok.DAL.Paging;

namespace Pustok.BLL.AutoMapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Product,ProductViewModel>().ReverseMap();
        CreateMap<Product,ProductPostViewModel>().ReverseMap();
        CreateMap<Product,ProductUpdateViewModel>().ReverseMap();

        CreateMap<Category,CategoryViewModel>().ReverseMap();
        CreateMap<Category,CategoryPostViewModel>().ReverseMap();
        CreateMap<Category,CategoryUpdateViewModel>().ReverseMap();
        CreateMap<CategoryViewModel,CategoryUpdateViewModel>().ReverseMap();
        CreateMap<Paginate<Category>,CategoryListViewModel>().ReverseMap();

        CreateMap<Tag,TagViewModel>().ReverseMap();
        CreateMap<Tag,TagPostViewModel>().ReverseMap();
        CreateMap<Tag,TagUpdateViewModel>().ReverseMap();
    }
}
