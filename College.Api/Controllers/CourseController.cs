using College.Api.DTOs.Course;
using College.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace College.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;

        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourseAll()
        {
            return Ok(await courseService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById([FromRoute]int id)
        {
            return Ok(await courseService.GetByIdAsync(id));
        }

        [HttpPost("{majorId}")]
        public async Task<IActionResult> CreateCourse([FromRoute] int majorId, [FromBody] CourseRequestDto requestDto)
        {
            var result = await courseService.CreateAsync(majorId, requestDto);

            return CreatedAtAction(nameof(GetCourseById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCours([FromRoute]int id, [FromBody] CourseRequestDto requestDto)
        {
            return Ok(await courseService.UpdateAsync(id, requestDto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse([FromRoute] int id)
        {
            await courseService.DeleteAsync(id);

            return NoContent();
        }
    }
}
