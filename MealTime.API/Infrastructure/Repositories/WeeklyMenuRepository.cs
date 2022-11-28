﻿using MealTime.Models;
using MealTime.Models.Repository;

namespace MealTime.API.Infrastructure.Repositories
{
    public class WeeklyMenuRepository : IWeeklyMenuRepository
    {
        private readonly MealTimeContext _context;
        public WeeklyMenuRepository(MealTimeContext context)
        {
            _context = context;
        }

        public async Task Create(WeeklyMenu menu, HashSet<int> mealIds)
        {
            menu.Meals.Clear();
            if (mealIds is not null)
                _context.Meals.Where(m => mealIds.Contains(m.Id)).ToList().ForEach(meal => menu.Meals.Add(meal));
            else
                throw new MealTimeException("Hiba történt a létrehozás során, menühöz nem tartoznak ételek.");
            _context.WeeklyMenus.Add(menu);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var menu = await _context.WeeklyMenus.FindAsync(id);
            if (menu == null)
            {
                throw new MealTimeException("Hiba történt a törlés során.");
            }
            _context.WeeklyMenus.Remove(menu);
            await _context.SaveChangesAsync();
        }
        public async Task Update(WeeklyMenu menu, HashSet<int> mealIds)
        {
            menu.Meals.Clear();
            if (mealIds is not null)
                _context.Meals.Where(m => mealIds.Contains(m.Id)).ToList().ForEach(meal => menu.Meals.Add(meal));
            _context.WeeklyMenus.Update(menu);
            var local = await _context.WeeklyMenus.FindAsync(menu.Id);
            if (local == null)
                throw new MealTimeException("Hiba történt a módosítás során.");
            else
                _context.Entry(local).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            _context.Entry(menu).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
