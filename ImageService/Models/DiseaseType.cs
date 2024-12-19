namespace ImageService.Models
{
    public class DiseaseType
    {
        public int Id { get; set; }
        public string Name { get; set; } // e.g., "Lung Cancer", "Brain Cancer"

        // Navigation property for related images
        public ICollection<Image> Images { get; set; } = new List<Image>();
    }
}
