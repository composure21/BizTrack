using BizTrack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BizTrack.Controllers
{
    public class TransactionsController : Controller
    {
        // Temporary in-memory list
        public static List<Transactions> transactions = new List<Transactions>();

        // GET: Transactions
        public IActionResult Index()
        {
            return View(transactions);
        }

        // GET: Transactions/Index
        public IActionResult Create()
        {
            LoadCategories();
            return View();
        }

        // POST: Transactions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Transactions transaction)
        {
            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(transaction);
            }

            transaction.TransactionId = transactions.Count > 0
                ? transactions.Max(t => t.TransactionId) + 1
                : 1;

            transactions.Add(transaction);

            return RedirectToAction(nameof(Index));
        }

        // GET: Transactions/Details/5
        public IActionResult Details(int id)
        {
            var transaction = transactions.FirstOrDefault(t => t.TransactionId == id);

            if (transaction == null)
                return NotFound();

            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public IActionResult Edit(int id)
        {
            var transaction = transactions.FirstOrDefault(t => t.TransactionId == id);

            if (transaction == null)
                return NotFound();

            LoadCategories();

            return View(transaction);
        }

        // POST: Transactions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Transactions transaction)
        {
            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(transaction);
            }

            var existing = transactions.FirstOrDefault(t =>
                t.TransactionId == transaction.TransactionId);

            if (existing == null)
                return NotFound();

            existing.Date = transaction.Date;
            existing.Description = transaction.Description;
            existing.CategoryId = transaction.CategoryId;
            existing.Type = transaction.Type;
            existing.Amount = transaction.Amount;
            existing.PaymentMethod = transaction.PaymentMethod;
            existing.Notes = transaction.Notes;

            // Show updated transaction
            return RedirectToAction(nameof(Index),
                new { id = existing.TransactionId });
        }

        // GET: Transactions/Delete/5
        public IActionResult Delete(int id)
        {
            var transaction = transactions.FirstOrDefault(t => t.TransactionId == id);

            if (transaction == null)
                return NotFound();

            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int transactionId)
        {
            var transaction = transactions.FirstOrDefault(t =>
                t.TransactionId == transactionId);

            if (transaction != null)
            {
                transactions.Remove(transaction);
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
