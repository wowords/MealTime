using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MealTime.Models;
using System.Net;
using MealTime.Models.Repository;
using MealTime.API.Infrastructure.Queries;

namespace MealTime.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly IFoodRepository _foodRepo;
        private readonly IFoodQueries _foodQueries;

        public FoodsController(MealTimeContext context, IFoodRepository foodRepo, IFoodQueries foodQueries)
        {
            _foodRepo = foodRepo;
            _foodQueries = foodQueries; 
        }

        // GET: api/Users
        [Route("GetFoods")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Food>>> GetUsers()
        {
            try
            {
                var result = await _foodQueries.GetAllFoods();
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
        [Route("GetFoodById")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Food>> GetFoodById(int foodId)
        {
            try
            {
                var result = await _foodQueries.GetFoodById(foodId);
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
        public async Task<IActionResult> Update(Food food)
        {
            if (food.Id <= 0)
                return BadRequest();
            try
            {
                await _foodRepo.Update(food);
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
        public async Task<ActionResult<Food>> AddFood(Food food)
        {
            if (food == null)
                return BadRequest();
            try
            {
                await _foodRepo.Create(food);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{foodId:int}/delete")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteFood(int id)
        {
            if (id <= 0)
                return BadRequest();
            try
            {
                await _foodRepo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
