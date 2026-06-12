using BizTrack.Models;
using Microsoft.AspNetCore.Mvc;

namespace BizTrack.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            // Get data from other controllers
            var incomeData = IncomeController.incomes;
            var expenseData = ExpensesController.expenses;
            var budgetData = BudgetController.budgets;
            var transactionData = TransactionsController.transactions;

            // Totals
            decimal totalIncome = incomeData.Sum(i => i.Amount);

            decimal totalExpenses = expenseData.Sum(e => e.Amount);

            decimal netSavings = totalIncome - totalExpenses;

            // Budget Progress
            decimal totalBudget = budgetData.Sum(b => b.BudgetAmount);

            decimal spentBudget = budgetData.Sum(b => b.SpentSoFar);

            int budgetProgress = totalBudget > 0
                ? (int)((spentBudget / totalBudget) * 100)
                : 0;

            // Recent Transactions
            var recentTransactions = transactionData
                .OrderByDescending(t => t.Date)
                .Take(5)
                .Select(t => new RecentTransactionViewModel
                {
                    Date = t.Date,
                    Description = t.Description,
                    CategoryId = t.CategoryId,
                    Amount = t.Amount,
                    IsIncome = t.Type == "Income"
                })
                .ToList();

            // Pie Chart Data (Expenses by Category)
            var expenseCategories = expenseData
                .GroupBy(e => e.CategoryId)
                .Select(g => $"Category {g.Key}")
                .ToList();

            var expenseCategoryTotals = expenseData
                .GroupBy(e => e.CategoryId)
                .Select(g => g.Sum(x => x.Amount))
                .ToList();

            // Dashboard Model
            var model = new Dashboard
            {
                TotalIncome = totalIncome,
                TotalExpenses = totalExpenses,
                NetSavings = netSavings,
                BudgetProgress = budgetProgress,
                RecentTransactions = recentTransactions,

                ExpenseCategories = expenseCategories,
                ExpenseCategoryTotals = expenseCategoryTotals
            };

            return View(model);
        }
    }
}