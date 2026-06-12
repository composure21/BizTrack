using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BizTrack.Models
{
    public class Budget
    {
        public int BudgetId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int CategoryId { get; set; }

        [Required]
        public int BudgetAmount { get; set; } 

        [Required]
        public int SpentSoFar { get; set; }

        public string Notes { get; set; }
    }
}
