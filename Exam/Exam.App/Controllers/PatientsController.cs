using Exam.App.Domain;
using Exam.App.Services.Dtos.PatientDto;
using Exam.App.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam.App.Controllers
{
    [Authorize(Roles = "Veterinarian,Assistent")]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientsController(IPatientService service)
        {
            _service = service;
        }

        //GET api/patients
        [HttpGet]
        public async Task<ActionResult<List<ResponsePatientDto>>> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }

        //GET api/patients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponsePatientDto>> GetByIdAsync(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        //GET api/patients
        [HttpPost]
        public async Task<ActionResult<ResponsePatientDto>> CreateAsync([FromBody] CreatePatientDto createPatient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _service.CreateAsync(createPatient));
        }

        //GET api/patients/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponsePatientDto>> UpdateAsync(int id, [FromBody] UpdatePatientDto patientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _service.UpdateAsync(id, patientDto));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            return NoContent();
        }
    }
}
