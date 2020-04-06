using BugTrackerUI.Tests;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace M2_BugTrackerUI.Tests.CreatingNavigationAndComponents
{
    public class M2_01_CreateNavigationComponentTests
    {
        [Fact(DisplayName = "Create the Navigation Component @create-navigation-component")]
        public void CreateNavigationComponentTest()
        {
            var filePath = TestHelpers.GetRootString() + "BugTrackerUI"
                + Path.DirectorySeparatorChar + "Shared"
                + Path.DirectorySeparatorChar + "LeftNav.razor";

            Assert.True(File.Exists(filePath), "`LeftNav.razor` should exist in the Shared folder.");
        }
    }
}
