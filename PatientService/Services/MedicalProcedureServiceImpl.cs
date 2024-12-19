using Microsoft.EntityFrameworkCore;
using PatientService.Data;
using PatientService.Models;

namespace PatientService.Services
{
    public class MedicalProcedureServiceImpl : IMedicalProcedureService
    {
        private readonly PatientDbContext _context;

        public MedicalProcedureServiceImpl(PatientDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MedicalProcedure>> GetProceduresAsync()
        {
            return await _context.MedicalProcedures.Include(p => p.Patient).Include(p => p.Condition).ToListAsync();
        }

        public async Task<MedicalProcedure?> GetProcedureByIdAsync(int id)
        {
            return await _context.MedicalProcedures.Include(p => p.Patient).Include(p => p.Condition).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<MedicalProcedure> CreateProcedureAsync(MedicalProcedure procedure)
        {
            _context.MedicalProcedures.Add(procedure);
            await _context.SaveChangesAsync();
            return procedure;
        }

        public async Task UpdateProcedureAsync(MedicalProcedure procedure)
        {
            _context.Entry(procedure).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteProcedureAsync(int id)
        {
            var procedure = await _context.MedicalProcedures.FindAsync(id);
            if (procedure == null) return false;

            _context.MedicalProcedures.Remove(procedure);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}