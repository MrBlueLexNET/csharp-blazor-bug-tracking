using BugTrackerUI.Tests;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace M5_BugTrackerUI.Tests.AddDataValidationToForm
{
    public class M5_03_AddValidatorComponentTests
    {
        [Fact(DisplayName = "Add the Validator Component @add-validator-component")]
        public void AddValidatorComponentTest()
        {
            var filePath = TestHelpers.GetRootString() + "BugTrackerUI"
                + Path.DirectorySeparatorChar + "Pages"
                + Path.DirectorySeparatorChar + "NewBug.razor";

            Assert.True(File.Exists(filePath), "`NewBug.razor` should exist in the Pages folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var dataValidator = doc.DocumentNode.Descendants("DataAnnotationsValidator")?.FirstOrDefault();

            Assert.True(dataValidator != null,
                "`NewBug.razor` should contain navigation `DataAnnotationsValidator` component.");
        }
    }
}
