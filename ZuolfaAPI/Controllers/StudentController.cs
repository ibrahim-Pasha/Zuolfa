using Business.Absttract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZuolfaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Student>>> GetAll()
        {
            var students = await _service.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("GetBy{id}")]
        public async Task<ActionResult<Student>> GetById(Guid id)
        {
            var student = await _service.GetByIdAsync(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<Student>> Create(Student student)
        {
            var created = await _service.CreateAsync(student);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("Update{id}")]
        public async Task<ActionResult<Student>> Update(Guid id, Student student)
        {
            var updated = await _service.UpdateAsync(id, student);
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
