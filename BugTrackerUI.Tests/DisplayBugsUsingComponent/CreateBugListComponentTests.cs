using BugTrackerUI.Tests;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace M6_BugTrackerUI.Tests.DisplayBugsUsingComponent
{
    public class M6_01_CreateBugListComponentTests
    {
        [Fact(DisplayName = "Create the BugList Component @create-buglist-component")]
        public void CreateNewBugComponentTest()
        {
            var filePath = TestHelpers.GetRootString() + "BugTrackerUI"
                + Path.DirectorySeparatorChar + "Components"
                + Path.DirectorySeparatorChar + "BugList.razor";

            Assert.True(File.Exists(filePath), "`BugList.razor` should exist in the Components folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var h3 = doc.DocumentNode.Descendants("h3")?.FirstOrDefault();

            Assert.True(h3 != null && h3.InnerText.Contains("All Bugs", StringComparison.OrdinalIgnoreCase),
                "The component `BugList.razor` should exist in the components folder and contain an `h3` element with the text `\"All Bugs\"`");
        }
    }
}
