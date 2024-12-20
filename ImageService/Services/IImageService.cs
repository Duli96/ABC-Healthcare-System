using Shared.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageService.Services
{
    public interface IImageService
    {
        Task<IEnumerable<Image>> GetImagesAsync();
        Task<Image?> GetImageByIdAsync(int id);
        Task<Image> UploadImageAsync(IFormFile file, int patientId, int imageTypeId, string imageType);
        Task<bool> DeleteImageAsync(int id);
    }
}
