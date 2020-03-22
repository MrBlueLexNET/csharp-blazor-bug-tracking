using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackerUI
{
    public interface IBugService
    {
        List<Bug> GetBugs();

        void AddBug(Bug newBug);
    }
}
