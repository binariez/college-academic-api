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
            return Ok(await enrollService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnrollmentById([FromRoute] int id)
        {
            return Ok(await enrollService.GetByIdAsync(id));
        }

        [HttpGet("student/{studentId}")]
        public async Task<IActionResult> GetEnrollmentByStudentId([FromRoute] int studentId)
        {
            return Ok(await enrollService.GetByStudentIdAsync(studentId));
        }

        // Hard delete by admin
        [HttpDelete("{enrollmentId}")]
        public async Task<IActionResult> DeleteEnrollment([FromRoute] int enrollmentId)
        {
            await enrollService.DeleteAsync(enrollmentId);

            return NoContent();
        }

        // Soft delete by student
        [HttpPut("student/drop/{enrollmentId}")]
        public async Task<IActionResult> DropEnrollment([FromRoute] int enrollmentId)
        {
            return Ok(await enrollService.DropEnrollmentAsync(enrollmentId));
        }

        // Ideally, this should be automatic. But for now I'm just putting it here
        [HttpPut("complete/{enrollmentId}")]
        public async Task<IActionResult> CompleteEnrollment([FromRoute] int enrollmentId)
        {
            return Ok(await enrollService.CompleteEnrollmentAsync(enrollmentId));
        }

        // For more information, ctrl + click the service method
        [HttpPut("student/reenroll/{enrollmentId}")]
        public async Task<IActionResult> ReEnroll([FromRoute] int enrollmentId)
        {
            return Ok(await enrollService.ReEnrollAsync(enrollmentId));
        }
    }
}
