namespace PatientService.Models
{
    public class MedicalProcedure
    {
        public int Id { get; set; }
        // Example: "MRI Scan"
        public string Description { get; set; } = string.Empty; 
        public DateTime TimeStamp { get; set; }

        // Foreign Key to Patient
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = new Patient();

        // Foreign Key to Condition
        public int ConditionId { get; set; }
        public Condition Condition { get; set; } = new Condition();

        public MedicalProcedure()
        {
            TimeStamp = DateTime.UtcNow;
        }
   
    }
}