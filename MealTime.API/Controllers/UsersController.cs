using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MealTime.Models;
using MealTime.Models.Repository;
using System.Net;
using MealTime.API.Infrastructure.Queries;

namespace MealTime.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly IUserQueries _userQueries;

        public UsersController(IUserRepository userRepo, IUserQueries userQueries)
        {
            _userRepo = userRepo;
            _userQueries = userQueries;
        }

        // GET: api/Users
        [Route("GetUsers")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                var result = await _userQueries.GetAllUsers();
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: api/Admins
        [Route("GetAdmins")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<User>>> GetAdmins()
        {
            try
            {
                var result = await _userQueries.GetAllUsers();
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }


        [Route("Update")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(User user)
        {
            if (user.Id <= 0)
                return BadRequest();
            try
            {
                await _userRepo.Update(user);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("Create")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            if(user == null)
                return BadRequest();
            try
            {
                await _userRepo.Create(user);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{userId:int}/delete")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id <= 0)
                return BadRequest();
            try
            {
                await _userRepo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
