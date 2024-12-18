using Microsoft.AspNetCore.Mvc;
using RegistrationManagementAPI.Entities;
using RegistrationManagementAPI.DTOs;
using RegistrationManagementAPI.Services.Interface;

namespace RegistrationManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            try
            {
                var course = await _courseService.GetCourseByIdAsync(id);
                return Ok(course);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] CourseDTO courseDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (courseDto.TeacherId <= 0)
                return BadRequest(new { message = "TeacherId is required and must be greater than 0." });

            var createdCourse = await _courseService.AddCourseAsync(courseDto);
            return CreatedAtAction(nameof(GetCourseById), new { id = createdCourse.CourseName }, createdCourse);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] CourseDTO courseDto)
        {
            try
            {
                await _courseService.UpdateCourseAsync(id, courseDto);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            try
            {
                await _courseService.DeleteCourseAsync(id);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("featured")]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetFeaturedCourses()
        {
            var courses = await _courseService.GetFeaturedCoursesAsync();

            if (courses == null || !courses.Any())
            {
                return NotFound("No featured courses available at the moment.");
            }

            return Ok(courses);
        }

        [HttpPut("increment-view/{id}")]
        public async Task<IActionResult> IncrementViewCount(int id)
        {
            var updatedCourse = await _courseService.IncrementViewCountAsync(id);

            if (updatedCourse == null)
            {
                return NotFound("Course not found or failed to update the view count.");
            }

            return Ok(updatedCourse); // Trả về đối tượng Course đã được cập nhật
        }

    }
}
