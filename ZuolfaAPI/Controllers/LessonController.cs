using Business.Absttract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZuolfaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _service;

        public LessonController(ILessonService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Lesson>>> GetAll()
        {
            var lessons = await _service.GetAllAsync();
            return Ok(lessons);
        }

        [HttpGet("GetBy{id}")]
        public async Task<ActionResult<Lesson>> GetById(Guid id)
        {
            var lesson = await _service.GetByIdAsync(id);
            if (lesson == null) return NotFound();
            return Ok(lesson);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<Lesson>> Create(Lesson lesson)
        {
            var created = await _service.CreateAsync(lesson);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("Update{id}")]
        public async Task<ActionResult<Lesson>> Update(Guid id, Lesson lesson)
        {
            var updated = await _service.UpdateAsync(id, lesson);
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
