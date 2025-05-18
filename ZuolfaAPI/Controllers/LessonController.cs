using Business.Absttract;
using Business.Concrete;
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

        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<Lesson>>> GetAll()
        {
            var lessons = await _service.GetAllAsync();
            return Ok(lessons);
        }

        [HttpGet("getby/{id}")]
        public async Task<ActionResult<Lesson>> GetById(Guid id)
        {
            var lesson = await _service.GetByIdAsync(id);
            if (lesson == null) return NotFound();
            return Ok(lesson);
        }

        [HttpPost("insert")]
        public async Task<ActionResult<Lesson>> Create(Lesson lesson)
        {
            var created = await _service.CreateAsync(lesson);
            return Ok( CreatedAtAction(nameof(GetById), new { id = created.Id }, created));
        }

        [HttpPost("insert/lessons")]
        public async Task<IActionResult> AddManyLessons([FromBody] List<Lesson> lessons)
        {
            var result = await _service.CreateManyAsync(lessons);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Lesson>> Update(Guid id, Lesson lesson)
        {
            var updated = await _service.UpdateAsync(id, lesson);
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
    }
}
