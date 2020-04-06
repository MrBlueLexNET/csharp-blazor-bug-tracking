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

namespace M6_BugTrackerUI.Tests.DisplayBugsUsingComponent
{
    public class MG_04_RetrieveListofBugsTests
    {
        [Fact(DisplayName = "Retrieve list of bugs @retrieve-buglist")]
        public void RetrieveListofBugsTest()
        {
            var filePath = TestHelpers.GetRootString() + "BugTrackerUI"
                + Path.DirectorySeparatorChar + "Components"
                + Path.DirectorySeparatorChar + "BugList.razor";

            Assert.True(File.Exists(filePath), "`BugList.razor` should exist in the Pages folder.");

            var newBug = TestHelpers.GetClassType("BugTrackerUI.Components.BugList");
            
            var method = newBug.GetMethod(
                "OnInitializedAsync",
                BindingFlags.Instance | BindingFlags.NonPublic);

            Assert.True( method != null && method.IsFamily && method.ReturnType == typeof(Task),
                "`BugList.razor` should contain a `protected` method called `OnInitializedAsync` that returns a type of `Task`.");
        }
    }
}
