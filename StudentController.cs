using Microsoft.AspNetCore.Mvc;
using StudentWebApi.Data;
using StudentWebApi.Models;

namespace StudentWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentRepository _repo;

        public StudentController(StudentRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_repo.GetAll());

        [HttpGet("{rn}")]
        public IActionResult GetByRn(int rn)
        {
            var student = _repo.GetByRn(rn);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            _repo.Add(student);
            return CreatedAtAction(nameof(GetByRn), new { rn = student.Rn }, student);
        }

        [HttpPut("{rn}")]
        public IActionResult Update(int rn, Student student)
        {
            if (rn != student.Rn) return BadRequest();
            _repo.Update(student);
            return NoContent();
        }

        [HttpDelete("{rn}")]
        public IActionResult Delete(int rn)
        {
            _repo.Delete(rn);
            return NoContent();
        }
    }
}
