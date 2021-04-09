using System;
using System.Collections.Generic;
using System.Data;
using bloggrCsharp.Models;
using Dapper;

namespace bloggrCsharp.Repositories
{
    public class BlogsRepository
    {
        private readonly IDbConnection _db;

        public BlogsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Blog> Get()
        {
            string sql = "SELECT * FROM blogs;";
            return _db.Query<Blog>(sql);
        }

        internal Blog Create(Blog newBlog)
        {
            string sql = @"
            INSERT INTO blogs
            (id, title, body, imgUrl, published, creatorId)
            VALUES
            (@Id, @Title, @Body, @ImgUrl, @Published, @CreatorId);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newBlog);
            newBlog.Id = id;
            return newBlog;
        }
    }
}