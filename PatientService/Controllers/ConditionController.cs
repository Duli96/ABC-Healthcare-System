using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using PatientService.Services;
using Shared.Models;
using Microsoft.AspNetCore.Authorization;

namespace PatientService.Controllers
{
    [Route("api/condition")]
    [ApiController]
    [Authorize]
    public class ConditionController : ControllerBase
    {
        private readonly IConditionService _conditionService;

        public ConditionController(IConditionService conditionService)
        {
            _conditionService = conditionService;
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN,DOCTOR,NURSE")]
        public async Task<ActionResult<IEnumerable<Condition>>> GetConditions()
        {
            var conditions = await _conditionService.GetConditionsAsync();
            return Ok(conditions);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "ADMIN,DOCTOR,NURSE")]
        public async Task<ActionResult<Condition>> GetCondition(int id)
        {
            var condition = await _conditionService.GetConditionByIdAsync(id);
            if (condition == null) return NotFound();
            return Ok(condition);
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN,DOCTOR")]
        public async Task<ActionResult<Condition>> CreateCondition(Condition condition)
        {
            var createdCondition = await _conditionService.CreateConditionAsync(condition);
            return CreatedAtAction(nameof(GetCondition), new { id = createdCondition.Id }, createdCondition);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN,DOCTOR")]
        public async Task<IActionResult> UpdateCondition(int id, Condition condition)
        {
            if (id != condition.Id) return BadRequest();
            await _conditionService.UpdateConditionAsync(condition);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> DeleteCondition(int id)
        {
            var success = await _conditionService.DeleteConditionAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}