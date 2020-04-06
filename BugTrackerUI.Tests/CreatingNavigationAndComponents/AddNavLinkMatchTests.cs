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
    public class M2_04_AddNavLinkMatchTests
    {
        [Fact(DisplayName = "Add the NavLink Match Attribute @add-navlink-match")]
        public void AddNavLinkMatchTest()
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

            var firstNavLink = firstLi.Descendants("NavLink").FirstOrDefault();
            Assert.True(firstNavLink != null && firstNavLink.Attributes["Match"]?.Value == "NavLinkMatch.All",
                @"The first `li` element should contain a `NavLink` component with with a `Match` attribute set to `""NavLinkMatch.All""` ");
        }
    }
}