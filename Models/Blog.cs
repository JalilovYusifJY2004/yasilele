namespace PraktikaPreskit.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string? Image { get; set; }
        public int ReplayCount { get; set; }
        public List<TagBlog>? TagBlogs  { get; set; }
    }
}
