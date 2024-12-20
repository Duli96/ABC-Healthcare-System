using System.Collections.Generic;

namespace Shared.Models
{
    public class DiseaseType
    {
        public int Id { get; set; }
        public string Name { get; set; } // Example: "Lung Cancer", "Brain Cancer"

        public ICollection<Image> Images { get; set; } = new List<Image>();
    }
}
