using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using PatientService.Data;
using Shared.Models;

namespace PatientService.Services
{
    public class ConditionServiceImpl : IConditionService
    {
        private readonly PatientDbContext _context;

        public ConditionServiceImpl(PatientDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Condition>> GetConditionsAsync()
        {
            return await _context.Conditions.Include(c => c.Procedures).ToListAsync();
        }

        public async Task<Condition?> GetConditionByIdAsync(int id)
        {
            return await _context.Conditions.Include(c => c.Procedures).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Condition> CreateConditionAsync(Condition condition)
        {
            _context.Conditions.Add(condition);
            await _context.SaveChangesAsync();
            return condition;
        }

        public async Task UpdateConditionAsync(Condition condition)
        {
            _context.Entry(condition).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteConditionAsync(int id)
        {
            var condition = await _context.Conditions.FindAsync(id);
            if (condition == null) return false;

            _context.Conditions.Remove(condition);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}