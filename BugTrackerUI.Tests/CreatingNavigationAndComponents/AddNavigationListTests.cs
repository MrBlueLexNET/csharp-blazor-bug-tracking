using BugTrackerUI.Tests;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace M2_BugTrackerUI.Tests.CreatingNavigationAndComponents
{
    public class M2_02_AddNavigationListTests
    {
        [Fact(DisplayName = "Add the Navigation List @add-navigation-list")]
        public void AddNavigationListTest()
        {
            var filePath = TestHelpers.GetRootString() + "BugTrackerUI"
                + Path.DirectorySeparatorChar + "Shared"
                + Path.DirectorySeparatorChar + "LeftNav.razor";

            Assert.True(File.Exists(filePath), "`LeftNav.razor` should exist in the Shared folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var ulTag = doc.DocumentNode.Descendants("ul")?.FirstOrDefault();

            Assert.True(ulTag != null && ulTag.Descendants("li") != null && ulTag.Descendants("li").Count() == 2,
                "`LeftNav.razor` should contain a `ul` element with two child `li` elements.");
        }
    }
}
