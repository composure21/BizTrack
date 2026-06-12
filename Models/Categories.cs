using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BizTrack.Models
{
    public class Categories
    {
        public int CategoryId { get; set; }
        public string  CategoryName { get; set; }

        [Required]
        public string Type { get; set; }

        public string Description  { get; set; }

        public string Icon { get; set; }
        public string Colour { get; set; }
    }
}
