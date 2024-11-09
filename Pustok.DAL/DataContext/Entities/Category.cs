    
namespace Pustok.DAL.DataContext.Entities;

public class Category : Timestample
{
    public required string Name { get; set; }
    public int ParentCategoryId { get; set; }
    public Category? ParentCategory { get; set; }
    public List<Category> SubCategories { get; set; } = [];
}
