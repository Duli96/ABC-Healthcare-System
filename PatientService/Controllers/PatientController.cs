using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using PatientService.Services;
using Microsoft.EntityFrameworkCore;
using PatientService.Data;
using Microsoft.AspNetCore.Authorization;

namespace PatientService.Controllers
{
    [Route("api/patient")]
    [ApiController]
    [Authorize] 
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN,DOCTOR,NURSE")] 
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            var patients = await _patientService.GetPatientsAsync();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "ADMIN,DOCTOR,NURSE")] 
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient == null) return NotFound();
            return Ok(patient);
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN,DOCTOR")] 
        public async Task<ActionResult<Patient>> CreatePatient(Patient patient)
        {
            var createdPatient = await _patientService.CreatePatientAsync(patient);
            return CreatedAtAction(nameof(GetPatient), new { id = createdPatient.Id }, createdPatient);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN,DOCTOR,NURSE")] 
        public async Task<IActionResult> UpdatePatient(int id, Patient patient)
        {
            if (id != patient.Id)
            {
                return BadRequest();
            }

            await _patientService.UpdatePatientAsync(patient);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")] 
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            await _patientService.DeletePatientAsync(id);
            return NoContent();
        }
    }
}