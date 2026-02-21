using Exam.App.Services.Dtos.AnimalSpeciesDto;
using Exam.App.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalSpeciesController : ControllerBase
    {
        private readonly IAnimalSpeciesService _service;

        public AnimalSpeciesController(IAnimalSpeciesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ResponseAnimalSpeciesDto>>> GetAllAsync() 
        { 
            return Ok(await _service.GetAllAsync());    
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseAnimalSpeciesDto>> GetByIdAsync(int id) 
        {
            return Ok(await _service.GetByIdAsync(id));
        }
    }
}
