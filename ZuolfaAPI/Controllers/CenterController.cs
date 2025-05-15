using Business.Absttract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZuolfaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CenterController : ControllerBase
    {
        private readonly ICenterService _service;

        public CenterController(ICenterService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Center>>> GetAll()
        {
            var centers = await _service.GetAllAsync();
            return Ok(centers);
        }

        [HttpGet("GetBy{id}")]
        public async Task<ActionResult<Center>> GetById(Guid id)
        {
            var center = await _service.GetByIdAsync(id);
            if (center == null) return NotFound();
            return Ok(center);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<Center>> Create(Center center)
        {
            var created = await _service.CreateAsync(center);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("Update{id}")]
        public async Task<ActionResult<Center>> Update(Guid id, Center center)
        {
            var updated = await _service.UpdateAsync(id, center);
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
