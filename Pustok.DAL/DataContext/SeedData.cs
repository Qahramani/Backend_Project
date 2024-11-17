namespace Pustok.DAL.DataContext;

public class SeedData
{
    public static void Seed(ModelBuilder builder)
    {
        builder.Entity<Tag>().HasData(
            new Tag { Id = 1, Link = "tag1" },
            new Tag { Id = 2, Link = "tag2" },
            new Tag { Id = 3, Link = "tag3" }
            );

        builder.Entity<Subscribe>().HasData(
           new Subscribe { Id = 1, Email = "gunel@mail.com" },
           new Subscribe { Id = 2, Email = "hello@ru" }
           );

        builder.Entity<Setting>().HasData(
            new Setting { Id = 1, Key = "Address", Value ="Baku / Code Academy" },
            new Setting { Id = 2, Key = "Facebook" , Value = "FatimVeliyev"},
            new Setting { Id = 3, Key = "Phone" , Value= "+18088 234 5678" }
            );
        builder.Entity<Slider>().HasData(
            new Slider { Id = 1, Title = "Qarisqalar Alemi", Description = "Bir var idi bir yox idi bir dene qarisqa var idi" ,OriginalPrice = 21.50M, DiscountPrice= 19.90M, ImageUrl = "https://res-console.cloudinary.com/dsclrbdnp/media_explorer_thumbnails/c1e28f6f87a43d4849a913702c851413/detailed" },
            new Slider { Id = 2, Title = "victor Hugo", Description = "nanananannananan" , OriginalPrice = 18.50M, DiscountPrice = 10.90M , ImageUrl = "https://res-console.cloudinary.com/dsclrbdnp/media_explorer_thumbnails/aeac4a238206d8eae3172146f7850b35/detailed" }
            );
        builder.Entity<Service>().HasData(
           new Service { Id = 1, MainText = "Free Shipping Item", SubText = "Orders over $500", IconUrl = "fas fa-shipping-fast" },
           new Service { Id = 2, MainText = "Money Back Guarantee", SubText = "100% money back", IconUrl = "fas fa-redo-alt" }
           );
        builder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Childer's Books", ImageUrl = "", },
            new Category { Id = 2, Name = "Literature", ImageUrl = "", },
            new Category { Id = 3, Name = "Russian Literature", ImageUrl = "", ParentCategoryId = 2 },
            new Category { Id = 4, Name = "Turkish Literature", ImageUrl = "", ParentCategoryId = 2 }
            );
        builder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Beats EP Wired On-Ear Headphone-Black", Description = "Long printed dress with thin adjustable straps. V-neckline and wiring under the Dust with ruffles at the bottom of the." ,
            Brand = "Canon",ProductCode = "nem", RewardPoint =10, Color = "qirmizi", StockQuantity = 10, Tax = 1, OriginalPrice =12.40M, CategoryId = 1}
            );
        builder.Entity<ProductImage>().HasData(
            new ProductImage { Id = 1, IsMain = true, ProductId = 1, ImageUrl = "https://res-console.cloudinary.com/dsclrbdnp/media_explorer_thumbnails/0b1b0cdf56beb5528272dcaa91a1085e/detailed" },
            new ProductImage { Id = 2, IsHover = true, ProductId = 1, ImageUrl = "https://res-console.cloudinary.com/dsclrbdnp/media_explorer_thumbnails/38b31592ce1c0c23b8e044ca8f39afcd/detailed" },
            new ProductImage { Id = 3, ProductId = 1, ImageUrl = "https://res-console.cloudinary.com/dsclrbdnp/media_explorer_thumbnails/23556821f4b0bb559e717d2d224bac32/detailed" }
            );
        builder.Entity<ProductTag>().HasData(
            new ProductTag { Id = 1, ProductId = 1, TagId = 1 },
            new ProductTag { Id = 2, ProductId = 1, TagId = 3 }
            );
    }
}
