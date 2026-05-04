using College.Api.DTOs.CourseClass;
using College.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace College.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseClassController : ControllerBase
    {
        private ICourseClassService ccService;

        public CourseClassController(ICourseClassService ccService)
        {
            this.ccService = ccService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourseClassAll()
        {
            return Ok(await ccService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseClassById([FromRoute] int id)
        {
            return Ok(await ccService.GetByIdAsync(id));
        }

        [HttpPost("{courseId}")]
        public async Task<IActionResult> CreateCourseClass([FromRoute]int courseId, [FromBody] CourseClassRequestDto requestDto)
        {
            var result = await ccService.CreateAsync(courseId, requestDto);

            return CreatedAtAction(nameof(GetCourseClassById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourseClass([FromRoute] int id, [FromBody] CourseClassRequestDto requestDto)
        {
            return Ok(await ccService.UpdateAsync(id, requestDto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseClass([FromRoute] int id)
        {
            await ccService.DeleteAsync(id);

            return NoContent();
        }
    }
}
