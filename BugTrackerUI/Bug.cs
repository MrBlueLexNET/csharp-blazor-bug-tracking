using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackerUI
{
    public class Bug
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [MinLength(length: 10)]
        public string Description { get; set; }
        [Required]
        [Range(minimum: 1, maximum: 5)]
        public int Priority { get; set; }
    }
}
