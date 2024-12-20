using System.Collections.Generic;

namespace Shared.Models
{
    public class ScanType
    {
        public int Id { get; set; }
        public string Name { get; set; } // Example: "MRI", "CT", "X-ray"

        public ICollection<Image> Images { get; set; } = new List<Image>();
    }
}
