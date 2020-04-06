using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;
using BugTrackerUI.Tests;

namespace M3_BugTrackerUI.Tests.CreatingNewBugForm
{
    public class M3_03_AddEditFormComponentTests
    {
        [Fact(DisplayName = "Add the Edit Form Components @add-editform-components")]
        public void AddEditFormComponentTest()
        {
            var filePath = TestHelpers.GetRootString() + "BugTrackerUI"
                + Path.DirectorySeparatorChar + "Pages"
                + Path.DirectorySeparatorChar + "NewBug.razor";

            Assert.True(File.Exists(filePath), "`NewBug.razor` should exist in the `Pages` folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var editForm = doc.DocumentNode.Descendants("EditForm")?.FirstOrDefault();

            Assert.True(editForm != null && editForm.Attributes["Model"]?.Value == "AddBug",
                @"The `NewBug` component element should contain an `EditForm` component with with a `Model` attribute set to `AddBug`.");
        }
    }
}