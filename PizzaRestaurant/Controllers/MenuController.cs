using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaRestaurant.Models;

namespace PizzaRestaurant.Controllers
{
    public class MenuController : Controller
    {
        private readonly ApplicationDBContext _db;

        [BindProperty]
        public MenuCategory MenuCategory { get; set; }
        [BindProperty]
        public MenuItem MenuItem { get; set; }
        [BindProperty]
        public FoodOptionSet FoodOptionSet { get; set; }
        [BindProperty]
        public FoodOption FoodOption { get; set; }

        public MenuController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Upserts a MenuCategory
        /// </summary>
        /// <param name="Key">The Id of the MenuCategory. Parameter is nullable</param>
        /// <returns></returns>
        public async Task<IActionResult> Upsert(int? Key)
        {
            // Only MenuCategory has Int Key Type

            MenuCategory = new MenuCategory();

            if (Key != null)
            {
                MenuCategory = await _db.MenuCategories.FirstOrDefaultAsync(u => u.MenuCategoryId == Key);

                if (MenuCategory == null)
                {
                    return NotFound();
                }

                return View(MenuCategory);
            }

            return View();
        }

        /// <summary>
        /// Upserts either FoodOption, FoodOptionSet, or MenuItem
        /// </summary>
        /// <param name="ObjectType">Type of item we're Upserting. "MenuItem", "FoodOptionSet" or "FoodOption"</param>
        /// <param name="Key">Id of the object we're Upserting. Parameter is nullable</param>
        /// <returns></returns>
        public async Task<IActionResult> Upsert(string ObjectType, Guid? Key)
        {
            if (ObjectType == "FoodOption")
            {
                FoodOption = new FoodOption();

                if (Key != null)
                {
                    FoodOption = await _db.FoodOptions.FirstOrDefaultAsync(u => u.FoodOptionId == Key);

                    if (FoodOption == null)
                    {
                        return NotFound();
                    }

                    return View(FoodOption);
                }

                return View();
            }

            else if (ObjectType == "FoodOptionSet")
            {
                FoodOptionSet = new FoodOptionSet();

                if (Key != null)
                {
                    FoodOptionSet = await _db.FoodOptionSets.FirstOrDefaultAsync(u => u.FoodOptionSetId == Key);

                    if (FoodOptionSet == null)
                    {
                        return NotFound();
                    }

                    return View(FoodOptionSet);
                }

                return View();

            }

            else
            {
                // MenuItem
                MenuItem = new MenuItem();

                if (Key != null)
                {
                    MenuItem = await _db.MenuItems.FirstOrDefaultAsync(u => u.MenuItemId == Key);

                    if (MenuItem == null)
                    {
                        return NotFound();
                    }

                    return View(MenuItem);
                }

                return View();
            }
        }

        #region API Calls
        [HttpPost]
        public async Task<IActionResult> UpsertMenuCategories(IList<MenuCategory> menuCategories)
        {
            foreach (MenuCategory menuCategory in menuCategories)
            {
                var categoryFromDb = await _db.MenuCategories.FirstOrDefaultAsync(u => u.MenuCategoryId == menuCategory.MenuCategoryId);
                if (categoryFromDb == null)
                {
                    try
                    {
                        // create
                        await _db.MenuCategories.AddAsync(menuCategory);
                        await _db.SaveChangesAsync();
                        continue;
                    } catch
                    {
                        return Json(new { success = false, message = "Error in Upserting New Category" });
                    }
                }
                else 
                {
                    try
                    {
                        // update
                        categoryFromDb.Name = menuCategory.Name;
                        categoryFromDb.MenuItems = menuCategory.MenuItems;
                        categoryFromDb.Description = menuCategory.Description;

                        await _db.SaveChangesAsync();
                    }
                    catch
                    {
                        return Json(new { success = false, message = "Error in Upserting Existing Category" });
                    }
                }
            }

            return Json(new { success = true, message = "Upsert Successful"});
        }

        [HttpGet]
        public async Task<IActionResult> GetMenuCategories()
        {
            return Json(new { data = await _db.MenuCategories.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMenuCategory(int id)
        {
            var categoryFromDB = await _db.MenuCategories.FirstOrDefaultAsync(u => u.MenuCategoryId == id);
            if (categoryFromDB == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.MenuCategories.Remove(categoryFromDB);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
        #endregion
    }
}