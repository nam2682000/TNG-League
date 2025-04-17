using Application.Extensions;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Application.Services;

class FileService : IFileService
{
    private readonly FileStorageOptions _options;
    public FileService(FileStorageOptions options)
    {
        _options = options;
    }

    public async Task<string> SaveFileAsync(IFormFile newFile, string subFolder = "images", string? oldFilePath = null)
    {
        // Xoá ảnh cũ nếu có
        if (!string.IsNullOrEmpty(oldFilePath))
        {
            var oldFullPath = Path.Combine(_options.WebRootPath, oldFilePath.TrimStart('/').Replace("/", Path.DirectorySeparatorChar.ToString()));
            if (File.Exists(oldFullPath))
            {
                File.Delete(oldFullPath);
            }
        }

        // Tạo tên file mới
        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(newFile.FileName);

        // Tạo thư mục nếu chưa tồn tại
        var folderPath = Path.Combine(_options.WebRootPath, "uploads", subFolder);
        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        // Lưu file mới
        var filePath = Path.Combine(folderPath, fileName);
        using var stream = new FileStream(filePath, FileMode.Create);
        await newFile.CopyToAsync(stream);

        // Trả về đường dẫn tương đối
        var relativePath = Path.Combine(subFolder, fileName).Replace("\\", "/");
        return $"/{relativePath}";
    }
}

