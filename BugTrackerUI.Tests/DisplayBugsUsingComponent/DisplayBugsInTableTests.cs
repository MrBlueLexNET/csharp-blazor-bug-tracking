using BugTrackerUI.Tests;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace M6_BugTrackerUI.Tests.DisplayBugsUsingComponent
{
    public class M6_06_DisplayBugsInTableTests
    {
        [Fact(DisplayName = "Display the List of Bugs in a Table @display-buglist-table")]
        public void DisplayBugsInTableTest()
        {
            var filePath = TestHelpers.GetRootString() + "BugTrackerUI"
                + Path.DirectorySeparatorChar + "Components"
                + Path.DirectorySeparatorChar + "BugList.razor";

            Assert.True(File.Exists(filePath), "`BugList.razor` should exist in the Shared folder.");

            string file;
            using (var streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }

            var pattern = @"<\s*?table\s*?>[\s\S]*?@foreach\s*?[(]\s*?(var|Bug)\s*bug\s*in\s*Bugs\s*?[)]\s*?{\s*?<\s*?[tT][rR]\s*?>\s*?<[tT][dD]>\s*?@bug.Id\s*?<\s*?\/\s*?[tT][dD]\s*?>\s*?\s*?<[tT][dD]>\s*?@bug.Title\s*?<\s*?\/\s*?[tT][dD]\s*?>\s*?\s*?<[tT][dD]>\s*?@bug.Description\s*?<\s*?\/\s*?[tT][dD]\s*?>\s*?\s*?<[tT][dD]>\s*?@bug.Priority\s*?<\s*?\/\s*?[tT][dD]\s*?>\s*?<\/\s*?[tT][rR]\s*?>\s*?}\s*?<\s*?\/table\s*?>";
            var rgx = new Regex(pattern);
            Assert.True(rgx.IsMatch(file), "`BugList.razor` was found, but does not appear to contain a `table` with a `foreach` loop that creates rows and columns for the `bug` items.");
        }
    }
}
