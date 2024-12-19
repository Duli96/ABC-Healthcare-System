namespace PatientService.Models{
    public class Patient {
        public int Id { get; set;}
        public string Name { get; set;} = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }

        // Collection of tasks
        public ICollection<Task> Tasks { get; set; } = new List<Task>();
        
        public Patient()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}