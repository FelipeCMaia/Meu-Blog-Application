using MeuBlog.Shared.Entities;

namespace MeuBlog.Domain.Entities
{
    public class Post : Entity
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Content { get; set; }        
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
