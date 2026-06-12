using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BizTrack.Models
{
    public class Dashboard
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal NetSavings { get; set; }
        public int BudgetProgress { get; set; }

        public List<RecentTransactionViewModel> RecentTransactions { get; set; }
            = new();

        // Chart Data
        public List<string> ExpenseCategories { get; set; }
            = new();

        public List<decimal> ExpenseCategoryTotals { get; set; }
            = new();
    }

    public class RecentTransactionViewModel
    {
        public DateTime Date { get; set; }
        public string Description { get; set; } = "";
        public int CategoryId { get; set; } 
        public decimal Amount { get; set; }
        public bool IsIncome { get; set; }
    }
}