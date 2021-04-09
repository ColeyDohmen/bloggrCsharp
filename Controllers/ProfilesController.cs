using System.Collections.Generic;
using bloggrCsharp.Models;
using bloggrCsharp.Services;
using Microsoft.AspNetCore.Mvc;

namespace bloggrCsharp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly ProfilesService _pservice;
        // private readonly AdmissionsService _admservice;

        public ProfilesController(ProfilesService pservice)
        {
            _pservice = pservice;

        }

        [HttpGet("{id}")]
        public ActionResult<Profile> Get(string id)
        {
            try
            {
                return Ok(_pservice.GetProfileById(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }


        // [HttpGet("{id}/admissions")]
        // public ActionResult<IEnumerable<Admission>> GetAdmissions(string id)
        // {
        //     try
        //     {
        //         return Ok(_admservice.GetAdmissionsByProfileId(id));
        //     }
        //     catch (System.Exception err)
        //     {
        //         return BadRequest(err.Message);
        //     }
        // }
    }

}