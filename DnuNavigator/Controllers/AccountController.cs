using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DnuNavigator.Data;
using System.Linq;
using DnuNavigator.Models;

namespace DnuNavigator.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ========== LOGIN SINH VIÊN ==========

        [HttpGet]
        public IActionResult Login()
        {
            return View(); // Trả về Views/Account/Login.cshtml
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // Nếu là tài khoản admin, redirect sang dashboard admin
            if (email == "admin@dainam.edu.vn" && password == "131208Happy")
            {
                HttpContext.Session.SetString("Role", "Admin");
                return RedirectToAction("Dashboard", "Admin");
            }

            // Xác thực sinh viên
            var student = _context.Students.FirstOrDefault(s => s.Email == email && s.PasswordHash == password);
            if (student != null)
            {
                HttpContext.Session.SetString("Role", "Student");
                HttpContext.Session.SetInt32("StudentId", student.Id);
                return RedirectToAction("Dashboard", "Student", new { id = student.Id });
            }

            // Sai thông tin
            ModelState.AddModelError("", "Email hoặc mật khẩu không đúng.");
            return View();
        }

        // ========== LOGIN ADMIN (trang riêng) ==========

        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View(); // Trả về Views/Account/AdminLogin.cshtml
        }

        [HttpPost]
        public IActionResult AdminLogin(string password)
        {
            const string adminPassword = "131208Happy";

            if (password == adminPassword)
            {
                HttpContext.Session.SetString("Role", "Admin");
                return RedirectToAction("Dashboard", "Admin");
            }

            ModelState.AddModelError("", "Mật khẩu không đúng.");
            return View();
        }

        // ========== LOGOUT ==========

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(string email, string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                ModelState.AddModelError("", "Mật khẩu xác nhận không khớp.");
                return View();
            }

            if (_context.Students.Any(s => s.Email == email))
            {
                ModelState.AddModelError("", "Email đã tồn tại.");
                return View();
            }

            var student = new Student
            {
                Email = email,
                PasswordHash = password // Bạn đã chọn bỏ hash, dùng luôn plain-text
            };

            _context.Students.Add(student);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

    }
}
