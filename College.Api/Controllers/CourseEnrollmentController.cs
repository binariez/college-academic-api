using College.Api.DTOs.CourseEnrollment;
using College.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace College.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseEnrollmentController : ControllerBase
    {
        private readonly ICourseEnrollmentService enrollService;

        public CourseEnrollmentController(ICourseEnrollmentService enrollService)
        {
            this.enrollService = enrollService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourseEnrollment([FromBody] CourseEnrollmentRequestDto requestDto)
        {
            try
            {
                var result = await enrollService.CreateAsync(requestDto);

                return CreatedAtAction(nameof(GetEnrollmentById), new { id = result.Id }, result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnrollmentById([FromRoute] int id)
        {
            var result = await enrollService.GetByIdAsync(id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpGet("student/{studentId}")]
        public async Task<IActionResult> GetEnrollmentByStudentId([FromRoute] int studentId)
        {
            var result = await enrollService.GetByStudentIdAsync(studentId);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpDelete("{enrollmentId}")]
        public async Task<IActionResult> DeleteEnrollment([FromRoute] int enrollmentId)
        {
            var result = await enrollService.DeleteAsync(id);

            if (result == null) return NotFound();

            return NoContent();
        }

        [HttpDelete("student/{enrollmentId}")]
        public IActionResult DropEnrollment([FromRoute] int enrollmentId)
        {

        }
    }
}
