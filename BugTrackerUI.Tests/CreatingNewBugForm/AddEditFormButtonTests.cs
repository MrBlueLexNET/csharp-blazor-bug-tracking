using BugTrackerUI.Tests;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace M3_BugTrackerUI.Tests.CreatingNewBugForm
{
    public class M3_05_AddEditFormButtonTests
    {
        [Fact(DisplayName = "Add the Edit Form Input Components @add-editform-inputs")]
        public void AddEditFormButtonTest()
        {
            var filePath = TestHelpers.GetRootString() + "BugTrackerUI"
                + Path.DirectorySeparatorChar + "Pages"
                + Path.DirectorySeparatorChar + "NewBug.razor";

            Assert.True(File.Exists(filePath), "`NewBug.razor` should exist in the `Pages` folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var editForm = doc.DocumentNode.Descendants("EditForm")?.FirstOrDefault();

            var labels = new[] { "Title", "Description", "Priority" };

            foreach (var label in labels)
            {
                var parsedInput = editForm.Descendants("button")
                    .FirstOrDefault(x => x.Attributes["type"]?.Value == $"submit");

                Assert.True(parsedInput != null && parsedInput.InnerText == "Add Bug", 
                    $"NewBug.razor should contain a button with attributes `type=\"submit\"` and the text `\"Add Bug\"`.");
            }
        }
    }
}