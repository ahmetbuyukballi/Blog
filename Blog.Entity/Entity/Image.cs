﻿using Blog.Core;

namespace Blog.Entity.Entity
{
    public class Image:EntityBase
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
