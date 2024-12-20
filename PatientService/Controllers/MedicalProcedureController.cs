using Microsoft.AspNetCore.Mvc;
using PatientService.Services;
using Shared.Models;
using Microsoft.AspNetCore.Authorization;

namespace PatientService.Controllers
{
    [Route("api/medicalProcedure")]
    [ApiController]
    [Authorize]
    public class MedicalProcedureController : ControllerBase
    {
        private readonly IMedicalProcedureService _medicalProcedureService;

        public MedicalProcedureController(IMedicalProcedureService medicalProcedureService)
        {
            _medicalProcedureService = medicalProcedureService;
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN,DOCTOR,NURSE")]
        public async Task<ActionResult<IEnumerable<MedicalProcedure>>> GetProcedures()
        {
            var procedures = await _medicalProcedureService.GetProceduresAsync();
            return Ok(procedures);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "ADMIN,DOCTOR,NURSE")]
        public async Task<ActionResult<MedicalProcedure>> GetProcedure(int id)
        {
            var procedure = await _medicalProcedureService.GetProcedureByIdAsync(id);
            if (procedure == null) return NotFound();
            return Ok(procedure);
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN,DOCTOR")]
        public async Task<ActionResult<MedicalProcedure>> CreateProcedure(MedicalProcedure procedure)
        {
            var createdProcedure = await _medicalProcedureService.CreateProcedureAsync(procedure);
            return CreatedAtAction(nameof(GetProcedure), new { id = createdProcedure.Id }, createdProcedure);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN,DOCTOR")]
        public async Task<IActionResult> UpdateProcedure(int id, MedicalProcedure procedure)
        {
            if (id != procedure.Id) return BadRequest();
            await _medicalProcedureService.UpdateProcedureAsync(procedure);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> DeleteProcedure(int id)
        {
            var success = await _medicalProcedureService.DeleteProcedureAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}