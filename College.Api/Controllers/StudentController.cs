using College.Api.DTOs.Student;
using College.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace College.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentAll()
        {
            return Ok(await studentService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            return Ok(await studentService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentRequestDto requestDto)
        {
            var result = await studentService.CreateAsync(requestDto);

            return CreatedAtAction(nameof(GetStudentById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] int id, [FromBody] StudentRequestDto requestDto)
        {
            return Ok(await studentService.UpdateAsync(id, requestDto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await studentService.DeleteAsync(id);

            return NoContent();
        }
    }
}