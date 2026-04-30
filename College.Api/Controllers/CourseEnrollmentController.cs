using College.Api.DTOs.CourseEnrollment;
using College.Api.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;

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

            return Ok(result);
        }

        [HttpGet("enrollment/{studentId}")]
        public async Task<IActionResult> GetEnrollmentByStudentId([FromRoute] int studentId)
        {
            var result = await enrollService.GetByStudentIdAsync(studentId);

            return Ok(result);
        }
    }
}
