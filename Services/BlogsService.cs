using System;
using System.Collections.Generic;
using bloggrCsharp.Models;
using bloggrCsharp.Repositories;

namespace bloggrCsharp.Services
{
    public class BlogsService
    {
        private readonly BlogsRepository _repo;

        public BlogsService(BlogsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Blog> Get()
        {
            return _repo.Get();
        }

        internal Blog Create(Blog newBlog)
        {
            return _repo.Create(newBlog);
        }
    }
}