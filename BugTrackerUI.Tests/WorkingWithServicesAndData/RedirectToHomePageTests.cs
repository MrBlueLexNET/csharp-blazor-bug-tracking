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

namespace M4_BugTrackerUI.Tests.WorkingWithServicesAndData
{
    public class M4_06_RedirectToHomePageTests
    {
        [Fact(DisplayName = "Redirect to the home page @redirect-to-home-page")]
        public void RedirectToHomePageTest()
        {
            var filePath = TestHelpers.GetRootString() + "BugTrackerUI"
                    + Path.DirectorySeparatorChar + "Pages"
                    + Path.DirectorySeparatorChar + "NewBug.razor";

            Assert.True(File.Exists(filePath), "`NewBug.razor` was not found.");

            string file;
            using (var streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }

            Assert.True(file.Contains("NavService.NavigateTo(\"\")"),
                "`NewBug.razor` does not contain a call to `NavService.NavigateTo()`.");
        }
    }
}
