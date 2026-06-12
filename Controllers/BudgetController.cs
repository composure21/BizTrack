using BizTrack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BizTrack.Controllers
{
    public class BudgetController : Controller
    {
        // Temporary in-memory list
        public static List<Budget> budgets = new List<Budget>();

        // GET: Transactions
        public IActionResult Index()
        {
            return View(budgets);
        }

        // GET: Budget/Index
        public IActionResult Create()
        {
            LoadCategories();
            return View();
        }

        // POST: Budget/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Budget budget)
        {
            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(budget);
            }

            budget.BudgetId = budgets.Count > 0
                ? budgets.Max(t => t.BudgetId) + 1
                : 1;

            budgets.Add(budget);

            return RedirectToAction(nameof(Index));
        }

        // GET: Budget/Details/5
        public IActionResult Details(int id)
        {
            var budget = budgets.FirstOrDefault(t => t.BudgetId == id);

            if (budget == null)
                return NotFound();

            return View(budget);
        }

        // GET: Budget/Edit/5
        public IActionResult Edit(int id)
        {
            var budget = budgets.FirstOrDefault(t => t.BudgetId == id);

            if (budget == null)
                return NotFound();

            LoadCategories();

            return View(budget);
        }

        // POST: Budget/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Budget budget)
        {
            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(budget);
            }

            var existing = budgets.FirstOrDefault(t =>
                t.BudgetId == budget.BudgetId);

            if (existing == null)
                return NotFound();

            existing.Date = budget.Date;
            existing.CategoryId = budget.CategoryId;
            existing.BudgetAmount = budget.BudgetAmount;
            existing.SpentSoFar = budget.SpentSoFar;
            existing.Notes = budget.Notes;

            // Show updated budget
            return RedirectToAction(nameof(Index),
                new { id = existing.BudgetId });
        }

        // GET: Budget/Delete/5
        public IActionResult Delete(int id)
        {
            var budget = budgets.FirstOrDefault(t => t.BudgetId == id);

            if (budget == null)
                return NotFound();

            return View(budget);
        }

        // POST: Budget/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int budgetId)
        {
            var budget = budgets.FirstOrDefault(t =>
                t.BudgetId == budgetId);

            if (budget != null)
            {
                budgets.Remove(budget);
            }

            return RedirectToAction(nameof(Index));
        }

        private void LoadCategories()
        {
            ViewBag.Categories = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Food" },
                new SelectListItem { Value = "2", Text = "Transport" },
                new SelectListItem { Value = "3", Text = "Housing" },
                new SelectListItem { Value = "4", Text = "Entertainment" },
                new SelectListItem { Value = "5", Text = "Utilities" }
            };
        }
    }
}