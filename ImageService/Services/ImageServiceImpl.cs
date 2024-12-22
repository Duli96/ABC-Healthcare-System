using Microsoft.EntityFrameworkCore;
using ImageService.Data;
using Shared.Models;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace ImageService.Services
{
    public class ImageServiceImpl : IImageService
    {
        private readonly ImageServiceDbContext _context;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IConfiguration _configuration;

        public ImageServiceImpl(IConfiguration configuration, ImageServiceDbContext context)
        {
            _configuration = configuration;
            _context = context;

            var connectionString = _configuration["AzureBlobStorage:ConnectionString"];
            _blobServiceClient = new BlobServiceClient(connectionString);
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
            if (file == null || file.Length == 0)
                throw new ArgumentException("Invalid file");

            var containerName = _configuration["AzureBlobStorage:ContainerName"];
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

            await containerClient.CreateIfNotExistsAsync(PublicAccessType.Blob);

            var blobClient = containerClient.GetBlobClient($"{Guid.NewGuid()}-{file.FileName}");

            using (var stream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, new BlobHttpHeaders { ContentType = file.ContentType });
            }

            var imageUrl = blobClient.Uri.ToString();

            var image = new Image
            {
                FileName = file.FileName,
                Url = imageUrl,
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
