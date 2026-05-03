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
            var result = await enrollService.CreateAsync(requestDto);

            return CreatedAtAction(nameof(GetEnrollmentById), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetEnrollmentAll()
        {
            var result = await enrollService.GetAllAsync();

            return Ok(result);
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

        // Hard delete by admin
        [HttpDelete("{enrollmentId}")]
        public async Task<IActionResult> DeleteEnrollment([FromRoute] int enrollmentId)
        {
            var result = await enrollService.DeleteAsync(enrollmentId);

            if (result == null) return NotFound();

            return NoContent();
        }

        // Soft delete by student
        [HttpPut("student/drop/{enrollmentId}")]
        public async Task<IActionResult> DropEnrollment([FromRoute] int enrollmentId)
        {
            var result = await enrollService.DropEnrollmentAsync(enrollmentId);

            if (result == null) return NotFound();

            return Ok(result);
        }

        // Ideally, this should be automatic. But for now I'm just putting it here
        [HttpPut("complete/{enrollmentId}")]
        public async Task<IActionResult> CompleteEnrollment([FromRoute] int enrollmentId)
        {
            var result = await enrollService.CompleteEnrollmentAsync(enrollmentId);

            if (result == null) return NotFound();

            return Ok(result);
        }

        // For more information, ctrl + click the service method
        [HttpPut("student/reenroll/{enrollmentId}")]
        public async Task<IActionResult> ReEnroll([FromRoute] int enrollmentId)
        {
            var result = await enrollService.ReEnrollAsync(enrollmentId);

            if (result == null) return NotFound();

            return Ok(result);
        }
    }
}
