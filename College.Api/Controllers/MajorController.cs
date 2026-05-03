using College.Api.DTOs.Major;
using College.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace College.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MajorController : ControllerBase
    {
        private readonly IMajorService majorService;

        public MajorController(IMajorService majorService)
        {
            this.majorService = majorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMajorAll()
        {
            var result = await majorService.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMajorById([FromRoute] int id)
        {
            var result = await majorService.GetByIdAsync(id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMajor([FromBody] MajorRequestDto requestDto)
        {
            var result = await majorService.CreateAsync(requestDto);

            return CreatedAtAction(nameof(GetMajorById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMajor([FromRoute] int id, MajorRequestDto majorDTO)
        {
            var result = await majorService.UpdateAsync(id, majorDTO);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMajor([FromRoute] int id)
        {
            var result = await majorService.DeleteAsync(id);

            if (result == null) return NotFound();

            return NoContent();
        }
    }
}
