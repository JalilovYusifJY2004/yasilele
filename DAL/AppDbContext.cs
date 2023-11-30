using Microsoft.EntityFrameworkCore;
using PraktikaPreskit.Models;

namespace PraktikaPreskit.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) 
        { 

        }
        public DbSet<Department>  Departments{ get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Tag> Tags  { get; set; }
        public DbSet<TagBlog> TagBlogs { get; set; }
    }
}
