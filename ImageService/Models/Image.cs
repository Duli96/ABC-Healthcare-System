using System;
using System.Collections.Generic;
using PatientService.Models;

namespace ImageService.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; } // Cloud storage URL
        public string ContentType { get; set; }
        public DateTime UploadedAt { get; set; }

        // Image classification
        public string ImageType { get; set; } // "ScanType" or "DiseaseType"
        public int ImageTypeId { get; set; }

        // Link to Patient
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
