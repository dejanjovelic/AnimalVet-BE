using Exam.App.Services.Dtos.AnimalSpeciesDto;
using Exam.App.Services.Dtos.OwnerDto;
using Exam.App.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService _service;

        public OwnersController(IOwnerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ResponseOwnerDto>>> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseOwnerDto>> GetByIdAsync(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }
    }
}