using System;
using System.Collections.Generic;
using Shared.Models;

namespace Shared.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }

        // Collection of procedures
        public ICollection<MedicalProcedure> Procedures { get; set; } = new List<MedicalProcedure>();
        
        // Navigation property for Images
        public ICollection<Image> Images { get; set; } = new List<Image>();

        public Patient()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}