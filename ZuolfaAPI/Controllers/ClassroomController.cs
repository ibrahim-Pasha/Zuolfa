﻿using Business.Absttract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZuolfaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly IClassroomService _service;

        public ClassroomController(IClassroomService service)
        {
            _service = service;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<Classroom>>> GetAll()
        {
            var classrooms = await _service.GetAllAsync();
            return Ok(classrooms);
        }

        [HttpGet("getby/{id}")]
        public async Task<ActionResult<Classroom>> GetById(Guid id)
        {
            var classroom = await _service.GetByIdAsync(id);
            if (classroom == null) return NotFound();
            return Ok(classroom);
        }

        [HttpPost("insert")]
        public async Task<ActionResult<Classroom>> Create(Classroom classroom)
        {
            var created = await _service.CreateAsync(classroom);
            return Ok( CreatedAtAction(nameof(GetById), new { id = created.Id }, created));
        }
        
        [HttpPut("update/{id}")]
        public async Task<ActionResult<Classroom>> Update(Guid id, Classroom classroom)
        {
            var updated = await _service.UpdateAsync(id, classroom);
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
