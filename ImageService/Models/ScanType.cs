namespace ImageService.Models
{
    public class ScanType
    {
        public int Id { get; set; }
        public string Name { get; set; } // e.g., "MRI", "CT", "X-ray"

        // Navigation property for related images
        public ICollection<Image> Images { get; set; } = new List<Image>();
    }
}
