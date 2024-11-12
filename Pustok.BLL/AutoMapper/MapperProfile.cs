using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.ViewModels;
using Pustok.DAL.Paging;

namespace Pustok.BLL.AutoMapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Product,ProductViewModel>().ReverseMap();
        CreateMap<Product,ProductCreateViewModel>().ReverseMap();
        CreateMap<Product,ProductUpdateViewModel>().ReverseMap();

        CreateMap<Category,CategoryViewModel>().ReverseMap();
        CreateMap<Category,CategoryCreateViewModel>().ReverseMap();
        CreateMap<Category,CategoryUpdateViewModel>().ReverseMap();
        CreateMap<CategoryViewModel,CategoryUpdateViewModel>().ReverseMap();
        CreateMap<Paginate<Category>,CategoryListViewModel>().ReverseMap();

        CreateMap<Tag,TagViewModel>().ReverseMap();
        CreateMap<Tag,TagCreateViewModel>().ReverseMap();
        CreateMap<Tag,TagUpdateViewModel>().ReverseMap();
        CreateMap<TagViewModel,TagUpdateViewModel>().ReverseMap();

        CreateMap<Service, ServiceViewModel>().ReverseMap();
        CreateMap<Service, ServiceCreateViewModel>().ReverseMap();
        CreateMap<Service ,ServiceUpdateViewModel>().ReverseMap();
        CreateMap<ServiceViewModel, ServiceUpdateViewModel>().ReverseMap();

        CreateMap<Setting, SettingViewModel>().ReverseMap();
        CreateMap<Setting, SettingCreateViewModel>().ReverseMap();
        CreateMap<Setting, SettingUpdateViewModel>().ReverseMap();
        CreateMap<SettingViewModel, SettingUpdateViewModel>().ReverseMap();
        CreateMap<Paginate<Setting>, SettingListViewModel>().ReverseMap();

        CreateMap<Subscribe, SubscribeViewModel>().ReverseMap();
        CreateMap<Subscribe, SubscribeCreateViewModel>().ReverseMap();
        CreateMap<Subscribe, SubscribeUpdateViewModel>().ReverseMap();
        CreateMap<SubscribeViewModel, SubscribeUpdateViewModel>().ReverseMap();
        CreateMap<Paginate<Subscribe>, SubscribeListViewModel>().ReverseMap();
    }
}
