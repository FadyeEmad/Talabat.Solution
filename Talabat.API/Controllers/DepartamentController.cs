using Microsoft.AspNetCore.Mvc;
using Talabat.API.DTOs;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;

namespace Talabat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentController : ControllerBase
    {
        private readonly IGenericRepository<Departament> _departamentRepo;

        public DepartamentController(IGenericRepository<Departament> departamentRepo)
        {
            _departamentRepo = departamentRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartamentDto>>> GetDepartments()
        {
            var departments = await _departamentRepo.GetAllAsync();

            var result = departments.Select(d => new DepartamentDto
            {
                Name = d.Name,
                CoursesCount = d.Courses?.Count ?? 0
            }).ToList();

            return Ok(result);
        }
    }
}
