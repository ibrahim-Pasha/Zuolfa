using Business.Absttract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZuolfaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseQuestionController : ControllerBase
    {
        private readonly IExerciseQuestionService _service;

        public ExerciseQuestionController(IExerciseQuestionService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<ExerciseQuestion>>> GetAll()
        {
            var questions = await _service.GetAllAsync();
            return Ok(questions);
        }

        [HttpGet("GetBy{id}")]
        public async Task<ActionResult<ExerciseQuestion>> GetById(Guid id)
        {
            var question = await _service.GetByIdAsync(id);
            if (question == null) return NotFound();
            return Ok(question);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<ExerciseQuestion>> Create(ExerciseQuestion question)
        {
            var created = await _service.CreateAsync(question);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("Update{id}")]
        public async Task<ActionResult<ExerciseQuestion>> Update(Guid id, ExerciseQuestion question)
        {
            var updated = await _service.UpdateAsync(id, question);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("Delete{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
