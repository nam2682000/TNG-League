using Microsoft.AspNetCore.Http;

namespace Application.Interfaces
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(IFormFile newFile, string subFolder = "images", string? oldFilePath = null);
    }
}
