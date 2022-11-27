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
        private readonly MealTimeContext _context;
        private readonly IUserRepository _userRepo;
        private readonly IUserQueries _userQueries;

        public UsersController(MealTimeContext context, IUserRepository userRepo, IUserQueries userQueries)
        {
            _context = context;
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

        // GET: api/Users/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<User>> GetUser(int id)
        //{        

        //}

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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
                _userRepo.Create(user);
                //return CreatedAtAction("GetUser", new { id = user.Id }, user);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Users/5
        [Route("Delete")]
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            //if (user == null)
            //{
            //    return NotFound();
            //}
            _userRepo.Delete(id);
            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
