using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MealTime.Models;
using MealTime.Models.Repository;
using MealTime.API.Infrastructure.Queries;
using System.Net;
using MealTime.API.Infrastructure.DataObjects;
using MealTime.API.Infrastructure.Helpers;

namespace MealTime.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        private readonly IMealRepository _mealRepo;
        private readonly IMealQueries _mealQueries;
        public MealsController(IMealRepository mealRepository, IMealQueries mealQueries, IFoodQueries foodQueries)
        {
            _mealQueries = mealQueries;
            _mealRepo = mealRepository;
        }

        [Route("GetMeals")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Meal>>> GetUsers()
        {
            try
            {
                var result = await _mealQueries.GetAllMeals();
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("GetMealById")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Meal>> GetFoodById(int mealId)
        {
            try
            {
                var result = await _mealQueries.GetMealByid(mealId);
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
        public async Task<IActionResult> Update(int mealId, List<int> foodIds)
        {
            if (mealId <= 0)
                return BadRequest();
            try
            {
                await _mealRepo.Update(mealId, foodIds.ToHashSet());
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
        public async Task<ActionResult<MealDto>> AddFood(MealDto mealDto)
        {
            
            if (mealDto == null)
                return BadRequest();
            try
            {
                var meal = new Meal() {Foods = new List<Food>() };
                await _mealRepo.Create(meal, mealDto.FoodIds.ToHashSet());
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{mealId:int}/delete")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteFood(int id)
        {
            if (id <= 0)
                return BadRequest();
            try
            {
                await _mealRepo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }        
    }
}
