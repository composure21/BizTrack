using BizTrack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BizTrack.Controllers
{
    public class IncomeController : Controller
    {
        // Temporary in-memory list
        public static List<Income> incomes = new List<Income>();

    // GET: Income
    public IActionResult Index()
        {
            return View(incomes);
        }

        // GET: Income/Create
        public IActionResult Create()
        {
            LoadCategories();
            return View();
        }

        // POST: Income/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Income income)
        {
            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(income);
            }

            income.IncomeId = incomes.Count > 0
                ? incomes.Max(i => i.IncomeId) + 1
                : 1;

            incomes.Add(income);

            return RedirectToAction(nameof(Index));
        }

        // GET: Income/Details/5
        public IActionResult Details(int id)
        {
            var income = incomes.FirstOrDefault(i => i.IncomeId == id);

            if (income == null)
                return NotFound();

            return View(income);
        }

        // GET: Income/Edit/5
        public IActionResult Edit(int id)
        {
            var income = incomes.FirstOrDefault(i => i.IncomeId == id);

            if (income == null)
                return NotFound();

            LoadCategories();

            return View(income);
        }

        // POST: Income/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Income income)
        {
            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(income);
            }

            var existing = incomes.FirstOrDefault(i =>
                i.IncomeId == income.IncomeId);

            if (existing == null)
                return NotFound();

            existing.Description = income.Description;
            existing.CategoryId = income.CategoryId;
            existing.Amount = income.Amount;
            existing.PaymentMethod = income.PaymentMethod;
            existing.Notes = income.Notes;

            return RedirectToAction(nameof(Index));
        }

        // GET: Income/Delete/5
        public IActionResult Delete(int id)
        {
            var income = incomes.FirstOrDefault(i => i.IncomeId == id);

            if (income == null)
                return NotFound();

            return View(income);
        }

        // POST: Income/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int incomeId)
        {
            var income = incomes.FirstOrDefault(i =>
                i.IncomeId == incomeId);

            if (income != null)
            {
                incomes.Remove(income);
            }

            return RedirectToAction(nameof(Index));
        }

        private void LoadCategories()
        {
            ViewBag.Categories = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Salary" },
            new SelectListItem { Value = "2", Text = "Bonus" },
            new SelectListItem { Value = "3", Text = "Freelance" },
            new SelectListItem { Value = "4", Text = "Investment" },
            new SelectListItem { Value = "5", Text = "Other" }
        };
        }
    }

}

