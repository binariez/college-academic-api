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
            return Ok(await majorService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMajorById([FromRoute] int id)
        {
            return Ok(await majorService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateMajor([FromBody] MajorRequestDto requestDto)
        {
            var result = await majorService.CreateAsync(requestDto);

            return CreatedAtAction(nameof(GetMajorById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMajor([FromRoute] int id, MajorRequestDto requestDto)
        {
            return Ok(await majorService.UpdateAsync(id, requestDto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMajor([FromRoute] int id)
        {
            await majorService.DeleteAsync(id);

            return NoContent();
        }
    }
}
