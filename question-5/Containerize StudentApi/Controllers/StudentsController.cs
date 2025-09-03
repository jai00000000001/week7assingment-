using Microsoft.AspNetCore.Mvc;
using StudentApiEf.Data;
using StudentApiEf.Models;

namespace StudentApiEf.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly StudentDbContext _context;

        public StudentsController(StudentDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Student> Get() => _context.Students.ToList();

        [HttpPost]
        public IActionResult Post(Student s)
        {
            _context.Students.Add(s);
            _context.SaveChanges();
            return Ok(s);
        }
    }
}
