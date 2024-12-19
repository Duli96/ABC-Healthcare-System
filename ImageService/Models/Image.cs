namespace ImageService.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; }
        public string ContentType { get; set; }
        public DateTime UploadedAt { get; set; }

        // ImageType attribute for custom classifications
        public string ImageType { get; set; } // e.g., "Diagnostic", "Report"

        // Foreign Key for ScanType
        public int ScanTypeId { get; set; }
        public ScanType ScanType { get; set; }

        // Foreign Key for DiseaseType
        public int DiseaseTypeId { get; set; }
        public DiseaseType DiseaseType { get; set; }

        // Foreign Key for Patient
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
