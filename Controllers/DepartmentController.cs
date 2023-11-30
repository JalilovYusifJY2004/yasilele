using Microsoft.AspNetCore.Mvc;
using PraktikaPreskit.DAL;
using PraktikaPreskit.Models;

namespace PraktikaPreskit.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly AppDbContext _context;

        public DepartmentController(AppDbContext context)
        {
              _context = context;
        }
        public IActionResult Index()
        {
       List<Department> departments= _context.Departments.ToList();
            return View(departments);
        }
    }
}
