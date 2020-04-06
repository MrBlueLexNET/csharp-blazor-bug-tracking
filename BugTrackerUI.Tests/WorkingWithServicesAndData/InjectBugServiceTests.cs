using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit;
using BugTrackerUI.Tests;

namespace M4_BugTrackerUI.Tests.WorkingWithServicesAndData
{
    public class M4_02_InjectBugServiceTests
    {
        [Fact(DisplayName = "Inject the Bug Service into NewBug Component @inject-bugservice-newbug-component")]
        public void InjectBugServiceTest()
        {
            var filePath = TestHelpers.GetRootString() + "BugTrackerUI"
                + Path.DirectorySeparatorChar + "Pages"
                + Path.DirectorySeparatorChar + "NewBug.razor";

            Assert.True(File.Exists(filePath), "`NewBug.razor` should exist in the Pages folder.");

            var newBug = TestHelpers.GetClassType("BugTrackerUI.Pages.NewBug");

            var prop = newBug.GetProperty("BugService");

            Assert.True(prop != null && prop.PropertyType.Name.Contains("IBugService")
                && newBug.IsPublic
                && newBug.GetProperty("BugService").Name.Contains("BugService"),
                "`NewBug.razor` should contain a public property `BugService` of type `IBugService`.");
        }
    }
}
