using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace BugTrackerUI.Tests.CreatingNavigationAndComponents
{
    public class AddNavigationToLayoutTests
    {
        [Fact(DisplayName = "Add the LeftNav Component to the MainLayout Component @add-leftnav-to-mainlayout")]
        public void AddNavigationToLayoutTest()
        {
            var filePath = TestHelpers.GetRootString() + "BugTrackerUI"
                + Path.DirectorySeparatorChar + "Shared"
                + Path.DirectorySeparatorChar + "MainLayout.razor";

            Assert.True(File.Exists(filePath), "`MainLayout.razor` should exist in the Shared folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var leftNav = doc.DocumentNode.Descendants("LeftNav")?.FirstOrDefault();

            Assert.True(leftNav != null,
                "`LeftNav.razor` should contain navigation `ul` element with two child `li` elements.");

        }
    }
}
