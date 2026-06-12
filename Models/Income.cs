using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BizTrack.Models
{
    public class Income
    {
        public int IncomeId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; }
        public string Notes { get; set; }
    }
}
