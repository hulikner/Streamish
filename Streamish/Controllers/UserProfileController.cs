using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Streamish.Models;
using Streamish.Repositories;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Streamish.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileRepository _profileRepo;
        public UserProfileController(IUserProfileRepository userProfileRepository)
        {
            _profileRepo = userProfileRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_profileRepo.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var userProfile = _profileRepo.GetById(id);
            if (userProfile == null)
            {
                return NotFound();
            }
            return Ok(userProfile);
        }

        [HttpPost]
        public IActionResult Post(UserProfile userProfile)
        {
            _profileRepo.Add(userProfile);
            return CreatedAtAction("Get", new { id = userProfile.Id }, userProfile);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UserProfile userProfile)
        {
            if (id != userProfile.Id)
            {
                return BadRequest();
            }

            _profileRepo.Update(userProfile);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _profileRepo.Delete(id);
            return NoContent();
        }

        [HttpGet("GetByIdWithVideos/{id}")]
        public IActionResult GetByIdWithVideos(int id)
        {
            var profile = _profileRepo.GetByIdWithVideos(id);
            return Ok(profile);
        }
    }
}
