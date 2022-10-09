using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolPrimaProject.Model;
using System.Reflection.Metadata;

namespace SchoolPrimaProject.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarksController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public MarksController(SchoolDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetSchool")]
        public async Task<IEnumerable<School>> GetSchool()
        {
            var List = await _context.Schools.ToListAsync();
            return List;
        }
        [HttpGet("GetStudent")]
        public async Task<IEnumerable<Studen>> GetStudent()
        {
            var List = await _context.Studens.ToListAsync();
            return List;
        }
        [HttpGet("GetStudentbySchool/{id}")]
        public async Task<IEnumerable<Studen>> GetStudentbySchool(int id)
        {
            var List = await _context.Studens.Where(x=>x.School_Id==id).ToListAsync();
            return List;
        }
        [HttpGet("Getmarkbystudent/{id}")]
        public async Task<IEnumerable<Marks>> Getmarkbystudent(int id)
        {
            var List = await _context.Marks.Where(x => x.Student_Id == id).ToListAsync();
            return List;
        }
        [HttpGet("Getmark")]
        public async Task<IEnumerable<Marks>> Getmark()
        {
            var List = await _context.Marks.ToListAsync();
            return List;
        }
        [HttpGet("GetTeacher")]
        public async Task<IEnumerable<Teacher>> GetTeacher()
        {
            var List = await _context.Teachers.ToListAsync();
            return List;
        }
        [HttpGet("GetSubject")]
        public async Task<IEnumerable<Subject>> GetSubject()
        {
            var List = await _context.Subjects.ToListAsync();
            return List;
        }

        [HttpPost]
        public async Task<IActionResult> Create( Marks blog)
        {
            if (ModelState.IsValid)
            {
                _context.Marks.Add(blog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return null;
        }

    }
}
