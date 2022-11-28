using MealTime.API.Infrastructure.Queries;
using MealTime.Models;
using MealTime.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MealTime.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly  IWeeklyMenuRepository _menuRepo;
        private readonly IWeeklyMenuQueries  _menuQueries;
        public MenuController(IWeeklyMenuRepository menuRepository, IWeeklyMenuQueries menuQueries)
        {
            _menuRepo = menuRepository;
            _menuQueries = menuQueries;
        }

        [Route("GetMenus")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<WeeklyMenu>>> GetUsers()
        {
            try
            {
                var result = await _menuQueries.GetAllMenus();
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("GetMenuById")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<WeeklyMenu>> GetFoodById(int menuId)
        {
            try
            {
                var result = await _menuQueries.GetMenuById(menuId);
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
        public async Task<IActionResult> Update(WeeklyMenu menu)
        {
            if (menu.Id <= 0)
                return BadRequest();
            try
            {
                await _menuRepo.Update(menu, menu.Meals.Select(x => x.Id).ToHashSet());
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
        public async Task<ActionResult<WeeklyMenu>> Addmenu(WeeklyMenu menu)
        {
            if (menu == null)
                return BadRequest();
            try
            {
                await _menuRepo .Create(menu, menu.Meals.Select(x => x.Id).ToHashSet());
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{menuId:int}/delete")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            if (id <= 0)
                return BadRequest();
            try
            {
                await _menuRepo.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
