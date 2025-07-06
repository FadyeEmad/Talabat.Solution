using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;

namespace Talabat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private static List<Courses> _courses = new List<Courses>();

        [HttpGet]
        public ActionResult<IEnumerable<Courses>> get()
        {
            if (_courses.Any())
                return Ok(_courses);

            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Courses>> deleteCourse(int id)
        {
            var course = _courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
                return NotFound();

            _courses.Remove(course);
            return Ok(_courses);
        }

        [HttpPut("{id}")]
        public ActionResult put(int id, Courses course)
        {
            if (id != course.Id)
                return BadRequest();

            var existingCourse = _courses.FirstOrDefault(c => c.Id == id);
            if (existingCourse == null)
                return NotFound();

            existingCourse.Crs_name = course.Crs_name;
            existingCourse.crs_desc = course.crs_desc;
            existingCourse.Duration = course.Duration;

            return NoContent();
        }

        [HttpPost]
        public ActionResult post(Courses course)
        {
            if (course == null)
                return BadRequest();

            course.Id = _courses.Any() ? _courses.Max(c => c.Id) + 1 : 1;
            _courses.Add(course);

            return StatusCode(201); // Created
        }

        [HttpGet("{id}")]
        public ActionResult<Courses> getById(int id)
        {
            var course = _courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
                return NotFound();

            return Ok(course);
        }

        [HttpGet("ByName/{name}")]
        public ActionResult<Courses> couseByName(string name)
        {
            var course = _courses.FirstOrDefault(c => c.Crs_name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (course == null)
                return NotFound();

            return Ok(course);
        }
    }
}
