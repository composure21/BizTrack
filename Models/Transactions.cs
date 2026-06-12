using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BizTrack.Models
{
    public class Transactions
    {
        public int TransactionId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        [Required]
        public string Type { get; set; } // Income / Expense

        [Required]
        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; }
        public string Notes { get; set; }
    }
}
