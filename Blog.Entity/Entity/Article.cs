using Blog.Core;

namespace Blog.Entity.Entity
{
    public class Article:EntityBase
    {   
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; }
        public Guid CategoryId { get; set; }
        public Category category { get; set; }
        public Guid ImageId { get; set; }
        public Image ımage { get; set; }
        
    }
}
