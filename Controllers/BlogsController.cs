using System;
using System.Collections.Generic;
using bloggrCsharp.Models;
using bloggrCsharp.Services;
using Microsoft.AspNetCore.Mvc;

namespace bloggrCsharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogsController : ControllerBase
    {
        private readonly BlogsService _service;

        public BlogsController(BlogsService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Blog>> Get()
        {
            try
            {
                return Ok(_service.Get());

            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public ActionResult<Blog> Create([FromBody] Blog newBlog)
        {
            try
            {
                return Ok(_service.Create(newBlog));

            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }
        }
    }
}