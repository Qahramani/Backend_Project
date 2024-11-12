namespace Pustok.BLL.Services.Abstraction;

public interface IProductService: ICrudService<Product, ProductViewModel, ProductListViewModel, ProductPostViewModel, ProductUpdateViewModel>
{
        
}

public interface ITagService : ICrudService<Tag, TagViewModel, TagListViewModel, TagPostViewModel, TagUpdateViewModel>
{

}