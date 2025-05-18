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

        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<ExerciseQuestion>>> GetAll()
        {
            var questions = await _service.GetAllAsync();
            return Ok(questions);
        }

        [HttpGet("getby/{id}")]
        public async Task<ActionResult<ExerciseQuestion>> GetById(Guid id)
        {
            var question = await _service.GetByIdAsync(id);
            if (question == null) return NotFound();
            return Ok(question);
        }

        [HttpPost("insert")]
        public async Task<ActionResult<ExerciseQuestion>> Create(ExerciseQuestion question)
        {
            var created = await _service.CreateAsync(question);
            return Ok( CreatedAtAction(nameof(GetById), new { id = created.Id }, created));
        }

        [HttpPost("insert/exercisequestions")]
        public async Task<IActionResult> AddManyStudents([FromBody] List<ExerciseQuestion> exerciseQuestion)
        {
            var result = await _service.CreateManyAsync(exerciseQuestion);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<ExerciseQuestion>> Update(Guid id, ExerciseQuestion question)
        {
            var updated = await _service.UpdateAsync(id, question);
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
        public async Task<ActionResult<IEnumerable<ExerciseQuestion>>> GetArchived()
        {
            var exercises = await _service.GetArchivedAsync();
            return Ok(exercises);
        }
    }
}
