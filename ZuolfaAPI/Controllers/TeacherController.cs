using Business.Absttract;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace ZuolfaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _service;

        public TeacherController(ITeacherService service)
        {
            _service = service;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetAll()
        {
            var teachers = await _service.GetAllAsync();
            return Ok(teachers);
        }

        [HttpGet("getby/{id}")]
        public async Task<ActionResult<Teacher>> GetById(Guid id)
        {
            var teacher = await _service.GetByIdAsync(id);
            if (teacher == null) return NotFound();
            return Ok(teacher);
        }

        [HttpPost("insert")]
        public async Task<ActionResult<Teacher>> Create(Teacher teacher)
        {
            var created = await _service.CreateAsync(teacher);
            return Ok( CreatedAtAction(nameof(GetById), new { id = created.Id }, created));
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Teacher>> Update(Guid id, Teacher teacher)
        {
            var updated = await _service.UpdateAsync(id, teacher);
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
