﻿namespace PraktikaPreskit.Models
{
    public class TagBlog
    {
        public int Id { get; set; }
        public int TagId { get; set; }
        public int BlogId { get; set; }
        public Tag Tag { get; set; }
        public Blog Blog { get; set; }

    }
}
