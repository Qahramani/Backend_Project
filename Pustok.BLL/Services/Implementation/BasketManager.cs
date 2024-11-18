using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pustok.BLL.Exceptions;
using Pustok.BLL.ViewModels;
using Pustok.DAL.DataContext.Entities;
using Pustok.DAL.Repositories.Abstraction;
using System.Security.Claims;

namespace Pustok.BLL.Services.Abstraction;

public class BasketManager : IBasketService
{
    private readonly IProductService _productService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IBasketItemRepository _basketItemRepository;
    private readonly IMapper _mapper;
    private const string PUSTOK_BASKET_KEY = "basket";

    public BasketManager(IProductService productService, IHttpContextAccessor httpContextAccessor, IBasketItemRepository basketItemRepository, IMapper mapper)
    {
        _productService = productService;
        _httpContextAccessor = httpContextAccessor;
        _basketItemRepository = basketItemRepository;
        _mapper = mapper;
    }

    public async Task AddToBasketAsync(int id)
    {
        var product = await _productService.GetAsync(id);

        if (product == null)
            throw new NotFoundException("Product not found");


        if (!_httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? true)
        {
            List<BasketItemVM> basket = _getBasketFromCookie();

            var basketItem = basket.FirstOrDefault(x => x.ProductId == id);

            if (basketItem != null)
                basketItem.Count++;
            else
            {
                BasketItemVM newProduct = new()
                {
                    ProductId = id,
                    Count = 1
                };
                basket.Add(newProduct);
            }

             _appendBasketInCookie(basket);
        }
        else
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null) throw new NotFoundException("User not found");

            var existItem = await _basketItemRepository.GetAsync(x => x.ProductId == product.Id && x.UserId == userId);

            if (existItem != null)
            {
                existItem.Count++;

                 await _basketItemRepository.UpdateAsync(existItem);

                return;
            }

            BasketItem item = new() { UserId = userId, ProductId = product.Id ,Count = 1};

            await _basketItemRepository.CreateAsync(item);

        }

    }



    public async Task<List<GetBasketViewModel>> ShoppingCardAsync()
    {
        List<GetBasketViewModel> basket = new();

        if (_httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false)
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId is null)
                throw new NotFoundException("user not found");

            var basketItemList = await _basketItemRepository.GetAllAsync(x => x.UserId == userId, include: x => x.Include(x => x.Product).ThenInclude(x => x.Images));

            foreach (var basketItem in basketItemList)
            {
                GetBasketViewModel vm = new()
                {
                    Id = basketItem.Id,
                    Count = basketItem.Count,
                    Price = basketItem.Product.OriginalPrice * (basketItem.Product.DiscountPercentage/100m),
                    ImagePath = basketItem.Product.Images?.FirstOrDefault(x => x.IsMain)?.ImageUrl ?? "",
                    Name = basketItem.Product.Name,
                    ProductId = basketItem.ProductId,
                };

                basket.Add(vm);
            }


            return basket;

        }


        List<BasketItemVM> basketItems = _getBasketFromCookie();

        foreach (var basketIem in basketItems)
        {

            var product = await _productService.GetAsync(x => x.Id == basketIem.ProductId, x => x.Include(x => x.Images));

            if (product is null)
                continue;

            GetBasketViewModel vm = new()
            {
                Count = basketIem.Count,
                Price = product.OriginalPrice * (product.DiscountPercentage / 100m),
                ImagePath = product.Images?.FirstOrDefault(x => x.IsMain)?.ImageUrl ?? "",
                Name = product.Name,
                ProductId = product.Id
            };

            basket.Add(vm);
        }


        return basket;
    }


    private void _appendBasketInCookie(List<BasketItemVM> basket)
    {
        var newJson = JsonConvert.SerializeObject(basket);

       _httpContextAccessor.HttpContext?.Response.Cookies.Append(PUSTOK_BASKET_KEY, newJson);
    }

    private List<BasketItemVM> _getBasketFromCookie()
    {
        string? json = _httpContextAccessor.HttpContext?.Request.Cookies[PUSTOK_BASKET_KEY];

        List<BasketItemVM> basket = new();

        if (!string.IsNullOrEmpty(json))
            basket = JsonConvert.DeserializeObject<List<BasketItemVM>>(json!) ?? new();
        return basket;
    }




}
