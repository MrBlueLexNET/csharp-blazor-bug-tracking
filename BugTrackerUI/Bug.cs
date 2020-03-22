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

        public string Title { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }
    }
}
