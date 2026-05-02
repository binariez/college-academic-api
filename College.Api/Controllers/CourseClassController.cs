using College.Api.DTOs.CourseClass;
using College.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace College.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseClassController : BaseController
    {
        private ICourseClassService ccService;

        public CourseClassController(ICourseClassService ccService)
        {
            this.ccService = ccService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourseClassAll()
        {
            var result = await ccService.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseClassById([FromRoute] int id)
        {
            var result = await ccService.GetByIdAsync(id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost("{courseId}")]
        public async Task<IActionResult> CreateCourseClass([FromRoute]int courseId, [FromBody] CourseClassRequestDto requestDto)
        {
            // DTO validation
            var errors = GetValidationErrors(requestDto);

            if (errors.Count != 0) return BadRequest(new { Errors = errors });

            // Proceed to service
            try
            {
                var result = await ccService.CreateAsync(courseId, requestDto);

                return CreatedAtAction(nameof(GetCourseClassById), new { id = result.Id }, result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourseClass([FromRoute] int id, [FromBody] CourseClassRequestDto requestDto)
        {
            // DTO validation
            var errors = GetValidationErrors(requestDto);

            if (errors.Count != 0) return BadRequest(new { Errors = errors });

            // Proceed to service
            var result = await ccService.UpdateAsync(id, requestDto);

            if (result == null) return NotFound();

            return CreatedAtAction(nameof(GetCourseClassById), new { id = result.Id }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseClass([FromRoute] int id)
        {
            var result = await ccService.DeleteAsync(id);

            if (result == null) return NotFound();

            return NoContent();
        }
    }
}
