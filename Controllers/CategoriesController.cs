using BizTrack.Models;
using Microsoft.AspNetCore.Mvc;

namespace BizTrack.Controllers
{
    public class CategoriesController : Controller
    {
        // Temporary in-memory storage
         public static List<Categories> categories = new();

        // GET: Categories
        public IActionResult Index()
        {
            return View(categories);
        }

        // GET: Categories/Create
        public IActionResult Create(int id = 0)
        {
            if (id == 0)
            {
                return View(new Categories());
            }

            var category = categories.FirstOrDefault(c => c.CategoryId == id);

            if (category == null)
                return NotFound();

            return View(category);
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categories category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            if (category.CategoryId == 0)
            {
                category.CategoryId = categories.Any()
                    ? categories.Max(c => c.CategoryId) + 1
                    : 1;

                categories.Add(category);
            }
            else
            {
                var existing = categories.FirstOrDefault(c =>
                    c.CategoryId == category.CategoryId);

                if (existing == null)
                    return NotFound();

                existing.CategoryName = category.CategoryName;
                existing.Type = category.Type;
                existing.Description = category.Description;
                existing.Icon = category.Icon;
                existing.Colour = category.Colour;
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Categories/Edit/5
        public IActionResult Edit(int id)
        {
            return RedirectToAction(nameof(Create), new { id });
        }

        // GET: Categories/Delete/5
        public IActionResult Delete(int id)
        {
            var category = categories.FirstOrDefault(c => c.CategoryId == id);

            if (category == null)
                return NotFound();

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = categories.FirstOrDefault(c => c.CategoryId == id);

            if (category != null)
            {
                categories.Remove(category);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}