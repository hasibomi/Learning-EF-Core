using System.Collections.Generic;
namespace EFCore.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public List<Post> Posts { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
