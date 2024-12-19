using System.Collections.Generic;
using System.Threading.Tasks;
using PatientService.Models;

namespace PatientService.Services
{
    public interface IMedicalProcedureService
    {
        Task<IEnumerable<MedicalProcedure>> GetProceduresAsync();
        Task<MedicalProcedure?> GetProcedureByIdAsync(int id);
        Task<MedicalProcedure> CreateProcedureAsync(MedicalProcedure procedure);
        Task UpdateProcedureAsync(MedicalProcedure procedure);
        Task<bool> DeleteProcedureAsync(int id);
    }
}