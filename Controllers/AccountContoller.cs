
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CodeWorks.Auth0Provider;
using bloggrCsharp.Services;
using bloggrCsharp.Models;

namespace bloggrCsharp.Controllers
{
    [ApiController]
    [Route("[controller]")]

    // REVIEW this tag enforces the user must be logged in
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly ProfilesService _pservice;
        // private readonly AdmissionsService _admservice;

        public AccountController(ProfilesService pservice)
        {
            _pservice = pservice;
        }

        [HttpGet]
        // REVIEW async calls must return a System.Threading.Tasks, this is equivalent to a promise in JS
        public async Task<ActionResult<Profile>> GetAsync()
        {
            try
            {
                // REVIEW how to get the user info from the request token
                // same as to req.userInfo
                //MAKE SURE TO BRING IN codeworks.auth0provider
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_pservice.GetOrCreateProfile(userInfo));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // [HttpGet("admissions")]
        // public async Task<ActionResult<IEnumerable<Admission>>> GetAdmissions()
        // {
        //     try
        //     {
        //         Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        //         return Ok(_admservice.GetAdmissionsByProfileId(userInfo.Id));
        //     }
        //     catch (System.Exception err)
        //     {
        //         return BadRequest(err.Message);
        //     }
        // }

    }
}