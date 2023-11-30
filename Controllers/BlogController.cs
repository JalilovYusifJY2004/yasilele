using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PraktikaPreskit.DAL;
using PraktikaPreskit.Models;

namespace PraktikaPreskit.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Blog> blogs = _context.Blogs.Include(b =>b.TagBlogs).ThenInclude(tb =>tb.Tag).ToList();

            return View(blogs);
        }
    }
}
