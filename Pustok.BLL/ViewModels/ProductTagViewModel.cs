namespace Pustok.BLL.ViewModels;

public class ProductTagViewModel : IViewModel
{
    public int Id { get; set; }
    public int TagId { get; set; }
    public TagViewModel? Tag { get; set; }
    public int ProductId { get; set; }
    public ProductViewModel? Product { get; set; }
}

public class ProductTagCreateViewModel : IViewModel
{
    public int TagId { get; set; }
    public int ProductId { get; set; }
}
public class ProductTagUpdateViewModel : IViewModel
{
    public int TagId { get; set; }
    public int ProductId { get; set; }
}
public class ProductTagListViewModel : PageableViewModel, IViewModel
{
    public List<ProductTagViewModel> Items { get; set; } = [];
}