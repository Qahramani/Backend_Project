using Microsoft.AspNetCore.Http;

namespace Pustok.BLL.Helpers.Contracts;


public interface ICloudinaryService
{
    Task<string> ImageCreateAsync(IFormFile file);
    Task<bool> FileDeleteAsync(string filePath);
    Task<string> FileCreateAsync(IFormFile file);
}

