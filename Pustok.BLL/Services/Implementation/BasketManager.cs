using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Pustok.BLL.Exceptions;
using System.Security.Claims;

namespace Pustok.BLL.Services.Abstraction;

public class BasketManager : IBasketService
{
    private readonly IProductService _productService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IBasketItemService _basketItemService;
    private readonly IMapper _mapper;
    private const string PUSTOK_BASKET_KEY = "basket";

    public BasketManager(IProductService productService, IHttpContextAccessor httpContextAccessor, IBasketItemService basketItemService, IMapper mapper)
    {
        _productService = productService;
        _httpContextAccessor = httpContextAccessor;
        _basketItemService = basketItemService;
        _mapper = mapper;
    }

    public async Task AddToBasketAsync(int id)
    {
        var product = await _productService.GetAsync(id);

        if (product == null)
            throw new NotFoundException("Product not found");


        if (!_httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? true)
        {
            string? json = _httpContextAccessor.HttpContext?.Request.Cookies[PUSTOK_BASKET_KEY];

            List<CookieBasketItemViewModel> basket = new();

            if (!string.IsNullOrEmpty(json))
                basket = JsonConvert.DeserializeObject<List<CookieBasketItemViewModel>>(json!) ?? new();

            var basketItem = basket.FirstOrDefault(x => x.ProductId == id);

            if (basketItem != null)
                basketItem.Count++;
            else
            {
                CookieBasketItemViewModel newProduct = new()
                {
                    ProductId = id,
                    Count = 1
                };
                basket.Add(newProduct);
            }

            var newJson = JsonConvert.SerializeObject(basket);

            _httpContextAccessor.HttpContext?.Response.Cookies.Append(PUSTOK_BASKET_KEY, newJson);
        }
        else
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null) throw new NotFoundException("User not found");

            var existItem = await _basketItemService.GetAsync(x => x.ProductId == product.Id);

            if (existItem != null)
            {
                existItem.Count++;

                //await _basketItemService.UpdateAsync(existItem);

                return;
            }

            BasketItemCreateViewModel item = new() { UserId = userId, ProductId = product.Id };

            await _basketItemService.CreateAsync(item);

        }

    }



}
