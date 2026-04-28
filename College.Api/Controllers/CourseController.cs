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
            var result = await courseService.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById([FromRoute]int id)
        {
            var result = await courseService.GetByIdAsync(id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost("{majorId}")]
        public async Task<IActionResult> CreateCourse([FromRoute] int majorId, [FromBody] CourseRequestDto requestDto)
        {
            try
            {
                var result = await courseService.CreateAsync(majorId, requestDto);

                return CreatedAtAction(nameof(GetCourseById), new { id = result.Id }, result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCours([FromRoute]int id, [FromBody] CourseRequestDto requestDto)
        {
            var updatedCourse = await courseService.UpdateAsync(id, requestDto);

            if (updatedCourse == null) return NotFound();

            return CreatedAtAction(nameof(GetCourseById), new { id = updatedCourse.Id }, updatedCourse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse([FromRoute] int id)
        {
            var deletedCourse = await courseService.DeleteAsync(id);

            if (deletedCourse == null) return NotFound();

            return NoContent();
        }
    }
}
