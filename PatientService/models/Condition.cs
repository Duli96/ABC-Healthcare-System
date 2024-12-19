namespace PatientService.Models
{
    public class Condition
    {
        public int Id { get; set; }
        // Example: "Diabetes"
        public string Name { get; set; } = string.Empty;
        // Example: "Type 1 Diabetes"
        public string Diagnosis { get; set; } = string.Empty;
        public DateTime DateDiagnosed { get; set; }

        // Navigation property for tasks
        public ICollection<Task> Tasks { get; set; } = new List<Task>();

        public Condition()
        {
            DateDiagnosed = DateTime.UtcNow;
        }
    }
}