using Microsoft.AspNetCore.Mvc;
using DnuNavigator.Data;
using System.Linq;

namespace DnuNavigator.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string search)
        {
            var students = _context.Students.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                students = students.Where(s => s.Email.Contains(search));
            }

            return View(students.ToList());
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // ✅ Đặt Dashboard trong class StudentController
        public IActionResult Dashboard(int id)
        {
            var subjects = _context.StudentSubjects
                .Where(ss => ss.StudentId == id)
                .Select(ss => ss.Subject)
                .ToList();

            return View(subjects); // Views/Student/Dashboard.cshtml
        }
    }
}