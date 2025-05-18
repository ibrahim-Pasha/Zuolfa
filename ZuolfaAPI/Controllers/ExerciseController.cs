using Business.Absttract;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace ZuolfaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _service;

        public ExerciseController(IExerciseService service)
        {
            _service = service;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<Exercise>>> GetAll()
        {
            var exercises = await _service.GetAllAsync();
            return Ok(exercises);
        }

        [HttpGet("getby/{id}")]
        public async Task<ActionResult<Exercise>> GetById(Guid id)
        {
            var exercise = await _service.GetByIdAsync(id);
            if (exercise == null) return NotFound();
            return Ok(exercise);
        }

        [HttpPost("insert")]
        public async Task<ActionResult<Exercise>> Create(Exercise exercise)
        {
            var created = await _service.CreateAsync(exercise);
            return Ok( CreatedAtAction(nameof(GetById), new { id = created.Id }, created));
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Exercise>> Update(Guid id, Exercise exercise)
        {
            var updated = await _service.UpdateAsync(id, exercise);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return Ok();
        }
        [HttpGet("getarchived")]
        public async Task<ActionResult<IEnumerable<Exercise>>> GetArchived()
        {
            var exercises = await _service.GetArchivedAsync();
            return Ok(exercises);
        }
    }
}
