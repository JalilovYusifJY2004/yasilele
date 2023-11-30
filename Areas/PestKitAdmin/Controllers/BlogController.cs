using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PraktikaPreskit.DAL;
using PraktikaPreskit.Models;

namespace PraktikaPreskit.Areas.PestKitAdmin.Controllers
{
    [Area("PestKitAdmin")]
    public class BlogController : Controller
    {

        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Blog> blogs = await _context.Blogs.ToListAsync();
            return View(blogs);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Blog blog)
        {
            if (!ModelState.IsValid) return View();

            bool result = await _context.Blogs.AnyAsync(b => b.Id == blog.Id);


            if (result)
            {
                ModelState.AddModelError("Blog", "Yanlisdir");
                return View();
            }

            await _context.AddAsync(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
        public async Task<IActionResult> Update(int Id)
        {
            if (Id <= 0) return BadRequest();
            Blog blog = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == Id);
            if (blog is null) return NotFound();
            return View(blog);

        }
        [HttpPost]
        public async Task<IActionResult> Update(int Id, Blog blog)
        {
            if (!ModelState.IsValid) return View();

            bool result = await _context.Blogs.AnyAsync(b => b.Id == Id);

            Blog existed = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == Id);
            if (existed is null) return NotFound();

            if (result)

                if (!result)
                {
                    ModelState.AddModelError("Blog", "Yanlisdir");
                    return View();
                }

                existed.Name= blog.Name;
            existed.Description= blog.Description;
            existed.Author= blog.Author;
             existed.ReplayCount= blog.ReplayCount;
            existed.Image= blog.Image;
          
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();

            Blog existed = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == id);
            if (existed is null) return NotFound();
            _context.Blogs.Remove(existed);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
    }
}
