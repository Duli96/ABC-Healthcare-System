using System.Collections.Generic;
using System.Threading.Tasks;
using PatientService.Models;

namespace PatientService.Services
{
    public interface IConditionService
    {
        Task<IEnumerable<Condition>> GetConditionsAsync();
        Task<Condition?> GetConditionByIdAsync(int id);
        Task<Condition> CreateConditionAsync(Condition condition);
        Task UpdateConditionAsync(Condition condition);
        Task<bool> DeleteConditionAsync(int id);
    }
}