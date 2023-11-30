namespace PraktikaPreskit.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TagBlog> TagBlogs { get; set; }

    }
}
