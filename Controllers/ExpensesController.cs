using BizTrack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BizTrack.Controllers
{
    public class ExpensesController : Controller
    {
        // Temporary in-memory list
        public static List<Expenses> expenses = new List<Expenses>();

        // GET: Income
        public IActionResult Index()
        {
            return View(expenses);
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
        public IActionResult Create(Expenses expense)
        {
            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(expense);
            }

            expense.ExpenseId = expenses.Count > 0
                ? expenses.Max(i => i.ExpenseId) + 1
                : 1;

            expenses.Add(expense);

            return RedirectToAction(nameof(Index));
        }

        // GET: Income/Details/5
        public IActionResult Details(int id)
        {
            var expense = expenses.FirstOrDefault(i => i.ExpenseId == id);

            if (expense == null)
                return NotFound();

            return View(expense);
        }

        // GET: Income/Edit/5
        public IActionResult Edit(int id)
        {
            var expense = expenses.FirstOrDefault(i => i.ExpenseId == id);

            if (expense == null)
                return NotFound();

            LoadCategories();

            return View(expense);
        }

        // POST: Income/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Expenses expense)
        {
            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(expense);
            }

            var existing = expenses.FirstOrDefault(i =>
                i.ExpenseId == expense.ExpenseId);

            if (existing == null)
                return NotFound();

            existing.Description = expense.Description;
            existing.CategoryId = expense.CategoryId;
            existing.Amount = expense.Amount;
            existing.PaymentMethod = expense.PaymentMethod;
            existing.Notes = expense.Notes;

            return RedirectToAction(nameof(Index));
        }

        // GET: Income/Delete/5
        public IActionResult Delete(int id)
        {
            var expense = expenses.FirstOrDefault(i => i.ExpenseId == id);

            if (expense == null)
                return NotFound();

            return View(expense);
        }

        // POST: Income/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int expenseId)
        {
            var expense = expenses.FirstOrDefault(i =>
                i.ExpenseId == expenseId);

            if (expense != null)
            {
                expenses.Remove(expense);
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
