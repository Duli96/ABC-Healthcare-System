using Microsoft.EntityFrameworkCore;
using ImageService.Data;
using Shared.Models;

namespace ImageService.Services
{
    public class ImageServiceImpl : IImageService
    {
        private readonly ImageServiceDbContext _context;

        public ImageServiceImpl(ImageServiceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Image>> GetImagesAsync()
        {
            return await _context.Images
                .Include(i => i.Patient)
                .ToListAsync();
        }

        public async Task<Image?> GetImageByIdAsync(int id)
        {
            return await _context.Images
                .Include(i => i.Patient)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Image> UploadImageAsync(IFormFile file, int patientId, int imageTypeId, string imageType)
        {
            string url = $"https://cloudstorage.com/{Guid.NewGuid() + Path.GetExtension(file.FileName)}";

            var image = new Image
            {
                FileName = file.FileName,
                Url = url,
                ContentType = file.ContentType,
                UploadedAt = DateTime.UtcNow,
                PatientId = patientId,
                ImageTypeId = imageTypeId,
                ImageType = imageType
            };

            _context.Images.Add(image);
            await _context.SaveChangesAsync();

            return image;
        }

        public async Task<bool> DeleteImageAsync(int id)
        {
            var image = await _context.Images.FindAsync(id);
            if (image == null) return false;

            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
