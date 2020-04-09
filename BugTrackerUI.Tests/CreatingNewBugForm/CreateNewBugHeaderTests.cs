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
    public class M3_01_CreateNewBugHeaderTests
    {
        [Fact(DisplayName = "Create the NewBug Header @create-newbug-header")]
        public void CreateNewBugHeaderTest()
        {
            var filePath = TestHelpers.GetRootString() + "BugTrackerUI"
                + Path.DirectorySeparatorChar + "Pages"
                + Path.DirectorySeparatorChar + "NewBug.razor";

            Assert.True(File.Exists(filePath), "`NewBug.razor` should exist in the Pages folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var h2 = doc.DocumentNode.Descendants("h3")?.FirstOrDefault();

            Assert.True(h2 != null && h2.InnerText.Contains("Add New Bug", StringComparison.OrdinalIgnoreCase), 
                "`NewBug.razor` should contain an `h3` tag with the text `\"Add New Bug\".`");
        }
    }
}
