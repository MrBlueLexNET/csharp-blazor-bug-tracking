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
    public class M2_03_AddNavigationNavLinkTests
    {
        [Fact(DisplayName = "Add the NavLink Components @add-navlink-components")]
        public void AddNavigationNavLinkTest()
        {
            var filePath = TestHelpers.GetRootString() + "BugTrackerUI"
                + Path.DirectorySeparatorChar + "Shared"
                + Path.DirectorySeparatorChar + "LeftNav.razor";

            Assert.True(File.Exists(filePath), "`LeftNav.razor` should exist in the Shared folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var ulTag = doc.DocumentNode.Descendants("ul")?.FirstOrDefault();

            Assert.True(ulTag != null && ulTag.Descendants("li") != null && ulTag.Descendants("li").Count() == 2,
                "`LeftNav.razor` should contain navigation `ul` element with two child `li` elements.");

            var firstLi = ulTag.Descendants("li").FirstOrDefault();
            var secondLi = ulTag.Descendants("li").ElementAt(1);

            var firstNavLink = firstLi.Descendants("NavLink").FirstOrDefault();
            Assert.True(firstNavLink != null && firstNavLink.Attributes["href"]?.Value == "" && firstNavLink.InnerText == "Home",
                "The first `li` element should contain a `NavLink` component with with an `href` set to `\"\"` and contain the text `\"Home\"`.");
            
            var secondNavLink = secondLi.Descendants("NavLink").FirstOrDefault();
            Assert.True(secondNavLink != null && secondNavLink.Attributes["href"]?.Value == "/new-bug" && secondNavLink.InnerText == "New Bug",
                "The second `li` element should contain a `NavLink` component with with an `href` set to `\"/new-bug\"` and contain the text `\"New Bug\"`.");
        }
    }
}