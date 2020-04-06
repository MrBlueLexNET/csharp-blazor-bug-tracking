using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit;
using BugTrackerUI.Tests;

namespace M6_BugTrackerUI.Tests.DisplayBugsUsingComponent
{
    public class M6_02_InjectBugServiceTests
    {
        [Fact(DisplayName = "Inject the Bug Service into BugList component @inject-bugservice-buglist-component")]
        public void InjectBugServiceTest()
        {
            var filePath = TestHelpers.GetRootString() + "BugTrackerUI"
                + Path.DirectorySeparatorChar + "Components"
                + Path.DirectorySeparatorChar + "BugList.razor";

            Assert.True(File.Exists(filePath), "`BugList.razor` should exist in the Components folder.");

            var newBug = TestHelpers.GetClassType("BugTrackerUI.Components.BugList");

            var prop = newBug.GetProperty("BugService");

            Assert.True(prop != null && prop.PropertyType.Name.Contains("IBugService")
                && newBug.IsPublic
                && newBug.GetProperty("BugService").Name.Contains("BugService"),
                "`BugList.razor` should contain a public property `BugService` of type `IBugService`.");
        }
    }
}
