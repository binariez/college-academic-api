using College.Api.DTOs.Student;
using College.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace College.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : BaseController
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentAll()
        {
            var students = await studentService.GetAllAsync();

            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var result = await studentService.GetByIdAsync(id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost("{majorId}")]
        public async Task<IActionResult> CreateStudent([FromRoute] int majorId, StudentRequestDto requestDto)
        {
            // DTO validation
            var errors = GetValidationErrors(requestDto);

            if (errors.Count != 0) return BadRequest(new { Errors = errors });

            // Proceed to service
            var createdStudent = await studentService.CreateAsync(majorId, requestDto);

            return CreatedAtAction(nameof(GetStudentById), new { id = createdStudent.Id }, createdStudent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] int id, [FromBody] StudentRequestDto requestDto)
        {
            // DTO validation
            var errors = GetValidationErrors(requestDto);

            if (errors.Count != 0) return BadRequest(new { Errors = errors });

            // Proceed to service
            var result = await studentService.UpdateAsync(id, requestDto);

            if (result == null) return NotFound();

            return CreatedAtAction(nameof(GetStudentById), new { id = result.Id }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await studentService.DeleteAsync(id);

            if (result == null) return NotFound();

            return NoContent();
        }
    }
}