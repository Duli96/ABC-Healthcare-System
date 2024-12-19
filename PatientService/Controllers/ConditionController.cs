using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using PatientService.Services;
using PatientService.Models;

namespace PatientService.Controllers
{
    [Route("api/condition")]
    [ApiController]
    public class ConditionController : ControllerBase
    {
        private readonly IConditionService _conditionService;

        public ConditionController(IConditionService conditionService)
        {
            _conditionService = conditionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Condition>>> GetConditions()
        {
            var conditions = await _conditionService.GetConditionsAsync();
            return Ok(conditions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Condition>> GetCondition(int id)
        {
            var condition = await _conditionService.GetConditionByIdAsync(id);
            if (condition == null) return NotFound();
            return Ok(condition);
        }

        [HttpPost]
        public async Task<ActionResult<Condition>> CreateCondition(Condition condition)
        {
            var createdCondition = await _conditionService.CreateConditionAsync(condition);
            return CreatedAtAction(nameof(GetCondition), new { id = createdCondition.Id }, createdCondition);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCondition(int id, Condition condition)
        {
            if (id != condition.Id) return BadRequest();
            await _conditionService.UpdateConditionAsync(condition);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCondition(int id)
        {
            var success = await _conditionService.DeleteConditionAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}