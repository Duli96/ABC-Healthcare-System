namespace Shared.Models
{
    public class Condition
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Diagnosis { get; set; } = string.Empty;
        public DateTime DateDiagnosed { get; set; }

        // Navigation property for procedures
        public ICollection<MedicalProcedure> Procedures { get; set; } = new List<MedicalProcedure>();

        public Condition()
        {
            DateDiagnosed = DateTime.UtcNow;
        }
    }
}