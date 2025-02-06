﻿using Blog.Core;

namespace Blog.Entity.Entity
{
    public class Category:EntityBase
    {
        public string Name { get; set; }
        
        public ICollection<Article> Articles { get; set; }
        
    }
}
