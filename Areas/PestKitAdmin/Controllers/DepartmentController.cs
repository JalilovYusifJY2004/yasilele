using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PraktikaPreskit.DAL;
using PraktikaPreskit.Models;

namespace PraktikaPreskit.Areas.PestKitAdmin.Controllers
{
    [Area("PestKitAdmin")]
    public class DepartmentController : Controller
    {

        private readonly AppDbContext _context;

        public DepartmentController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Department> departments = await _context.Departments.ToListAsync();
            return View(departments);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            if (!ModelState.IsValid) return View();

            bool result = await _context.Departments.AnyAsync(d => d.Id == department.Id);


            if (result)
            {
                ModelState.AddModelError("Department", "Yanlisdir");
                return View();
            }

            await _context.AddAsync(department);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
        public async Task<IActionResult> Update(int Id)
        {
            if (Id <= 0) return BadRequest();
            Department department = await _context.Departments.FirstOrDefaultAsync(d => d.Id == Id);
            if (department is null) return NotFound();
            return View(department);

        }
        [HttpPost]
        public async Task<IActionResult> Update(int Id, Department department)
        {
            if (!ModelState.IsValid) return View();

            bool result = await _context.Departments.AnyAsync(d => d.Id == Id);

            Department existed = await _context.Departments.FirstOrDefaultAsync(d => d.Id == Id);
            if (existed is null) return NotFound();

            if (result)

                if (!result)
                {
                    ModelState.AddModelError("Department", "Yanlisdir");
                    return View();
                }

            existed.Name = department.Name;
            existed.Image = department.Image;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();

            Department existed = await _context.Departments.FirstOrDefaultAsync(d => d.Id == id);
            if (existed is null) return NotFound();
            _context.Departments.Remove(existed);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
    }
}
