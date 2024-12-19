using Microsoft.AspNetCore.Mvc;
using PatientService.Services;
using PatientService.Models;

namespace PatientService.Controllers
{
    [Route("api/medicalProcedure")]
    [ApiController]
    public class MedicalProcedureController : ControllerBase
    {
        private readonly IMedicalProcedureService _medicalProcedureService;

        public MedicalProcedureController(IMedicalProcedureService medicalProcedureService)
        {
            _medicalProcedureService = medicalProcedureService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalProcedure>>> GetProcedures()
        {
            var procedures = await _medicalProcedureService.GetProceduresAsync();
            return Ok(procedures);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalProcedure>> GetProcedure(int id)
        {
            var procedure = await _medicalProcedureService.GetProcedureByIdAsync(id);
            if (procedure == null) return NotFound();
            return Ok(procedure);
        }

        [HttpPost]
        public async Task<ActionResult<MedicalProcedure>> CreateProcedure(MedicalProcedure procedure)
        {
            var createdProcedure = await _medicalProcedureService.CreateProcedureAsync(procedure);
            return CreatedAtAction(nameof(GetProcedure), new { id = createdProcedure.Id }, createdProcedure);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProcedure(int id, MedicalProcedure procedure)
        {
            if (id != procedure.Id) return BadRequest();
            await _medicalProcedureService.UpdateProcedureAsync(procedure);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProcedure(int id)
        {
            var success = await _medicalProcedureService.DeleteProcedureAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}