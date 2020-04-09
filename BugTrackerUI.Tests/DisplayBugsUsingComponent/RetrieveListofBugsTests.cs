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
    public class M6_06_RetrieveListofBugsTests
    {
        [Fact(DisplayName = "Retrieve list of bugs @retrieve-buglist")]
        public void RetrieveListofBugsTest()
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

            var pattern = @"\s*?protected\s*?override\s*?async\s*?Task\s*?OnInitializedAsync[(][)]\s*?[{]\s*?Bugs\s*?=\s*?BugService.GetBugs[(][)];\s*?}\s*?";
            var rgx = new Regex(pattern);
            Assert.True(rgx.IsMatch(file), "`BugList.razor` was found, but does not contain a `protected async` method called `OnInitializedAsync` that retrieves the list of Bugs.");
        }
    }
}
