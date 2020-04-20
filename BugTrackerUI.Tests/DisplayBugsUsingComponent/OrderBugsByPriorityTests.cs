using BugTrackerUI.Pages;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BugTrackerUI.Tests;
using System.Text.RegularExpressions;

namespace M6_BugTrackerUI.Tests.DisplayBugsUsingComponent
{
    public class M6_05_OrderBugsByPriorityTests
    {
        [Fact(DisplayName = "Order the list of bugs by priority @order-buglist")]
        public void OrderBugsByPriorityTest()
        {
            var filePath = TestHelpers.GetRootString() + "BugTrackerUI"
                + Path.DirectorySeparatorChar + "Components"
                + Path.DirectorySeparatorChar + "BugList.razor";

            Assert.True(File.Exists(filePath), "`BugList.razor` should exist in the Pages folder.");

            string file;
            using (var streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }

            Assert.True(file.Contains("BugService.GetBugs().OrderBy(x => x.Priority).ToList()"),
                "`BugList.razor` did not contain a call to `OrderBy` on the list of Bugs.");
        }
    }
}
