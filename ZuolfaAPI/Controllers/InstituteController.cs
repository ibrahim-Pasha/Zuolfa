﻿using Business.Absttract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZuolfaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstituteController : ControllerBase
    {
        private readonly IInstituteService _service;

        public InstituteController(IInstituteService service)
        {
            _service = service;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("getby/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return Ok(null);
            return Ok(result);
        }

        [HttpPost("insert")]
        public async Task<IActionResult> Create(Institute institute)
        {
            var created = await _service.CreateAsync(institute);
            return Ok( CreatedAtAction(nameof(GetById), new { id = created.Id }, created));
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromRoute]Guid id, Institute institute)
        {
            var updated = await _service.UpdateAsync(id, institute);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound();
            return Ok();
        }
    }
}
