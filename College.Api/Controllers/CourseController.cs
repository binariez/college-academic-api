using College.Api.DTOs.Course;
using College.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace College.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : BaseController
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
            // DTO validation
            var errors = GetValidationErrors(requestDto);

            if (errors.Count != 0) return BadRequest(new { Errors = errors });

            // Proceed to service
            var result = await courseService.CreateAsync(majorId, requestDto);

            return CreatedAtAction(nameof(GetCourseById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCours([FromRoute]int id, [FromBody] CourseRequestDto requestDto)
        {
            // DTO validation
            var errors = GetValidationErrors(requestDto);

            if (errors.Count != 0) return BadRequest(new { Errors = errors });

            // Proceed to service
            var result = await courseService.UpdateAsync(id, requestDto);

            if (result == null) return NotFound();

            return CreatedAtAction(nameof(GetCourseById), new { id = result.Id }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse([FromRoute] int id)
        {
            var result = await courseService.DeleteAsync(id);

            if (result == null) return NotFound();

            return NoContent();
        }
    }
}
