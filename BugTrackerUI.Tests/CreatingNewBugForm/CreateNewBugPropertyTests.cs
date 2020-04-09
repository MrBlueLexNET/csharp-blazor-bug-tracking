using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit;
using BugTrackerUI.Tests;

namespace M3_BugTrackerUI.Tests.CreatingNewBugForm
{
    public class M3_02_CreateNewBugPropertyTests
    {
        [Fact(DisplayName = "Create the AddBug Property @create-addbug-property")]
        public void CreateNewBugPropertyTest()
        {
            var filePath = TestHelpers.GetRootString() + "BugTrackerUI"
                + Path.DirectorySeparatorChar + "Pages"
                + Path.DirectorySeparatorChar + "NewBug.razor";

            Assert.True(File.Exists(filePath), "`NewBug.razor` should exist in the Pages folder.");

            var newBug = TestHelpers.GetClassType("BugTrackerUI.Pages.NewBug");

            var prop = newBug.GetProperty("AddBug");

            Assert.True(prop != null && prop.PropertyType.Name.Contains("Bug")
                && newBug.IsPublic
                && newBug.GetProperty("AddBug").Name.Contains("AddBug"),
                "`NewBug.razor` should contain a public property `AddBug` of type `Bug`.");
        }
    }
}
