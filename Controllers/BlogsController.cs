using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using bloggrCsharp.Models;
using bloggrCsharp.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("{id}")]
        public ActionResult<Blog> Get(int id)
        {
            try
            {
                return Ok(_service.GetById(id));
            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Blog>> CreateAsync([FromBody] Blog newBlog)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                newBlog.CreatorId = userInfo.Id;
                Blog created = _service.Create(newBlog);
                //this is your 'populate' for create
                created.Creator = userInfo;
                return Ok(created);

            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }
        }
    }
}