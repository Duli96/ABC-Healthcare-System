using System.Collections.Generic;
using System.Threading.Tasks;
using PatientService.Models;

namespace PatientService.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetPatientsAsync();
        Task<Patient> GetPatientByIdAsync(int id);
        Task<Patient> CreatePatientAsync(Patient patient);
        Task UpdatePatientAsync(Patient patient);
        Task DeletePatientAsync(int id);
    }
}