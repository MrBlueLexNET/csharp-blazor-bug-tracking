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
    public class M3_04_AddEditFormInputsTests
    {
        [Fact(DisplayName = "Add the Edit Form Input Components @add-editform-inputs")]
        public void AddEditFormInputsTest()
        {
            var filePath = TestHelpers.GetRootString() + "BugTrackerUI"
                + Path.DirectorySeparatorChar + "Pages"
                + Path.DirectorySeparatorChar + "NewBug.razor";

            Assert.True(File.Exists(filePath), "`NewBug.razor` should exist in the `Pages` folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var editForm = doc.DocumentNode.Descendants("EditForm")?.FirstOrDefault();

            if (editForm != null)
            {
                var labels = new[] { "Title", "Description", "Priority" };

                foreach (var label in labels)
                {
                    var inputType = "Text";
                    var parsedInput = editForm.Descendants("InputText")
                        .FirstOrDefault(x => x.Attributes["placeholder"]?.Value == $"Enter {label}" && x.Attributes["@bind-Value"]?.Value == $"@AddBug.{label}");

                    if (parsedInput == null)
                    {
                        parsedInput = editForm.Descendants("InputNumber")
                            .FirstOrDefault(x => x.Attributes["placeholder"]?.Value == $"Enter {label}" && x.Attributes["@bind-Value"]?.Value == $"@AddBug.{label}");

                        if (parsedInput != null)
                        {
                            inputType = "Number";
                        }
                    }

                    Assert.True(parsedInput != null,
                        $"The EditForm component should contain an Input{inputType} component with attributes `placeholder=\"Enter {label}\"` and `@bind-value=\"@AddBug.{label}\"`");
                }
            }
            else
            {
                Assert.True(editForm != null,
                @"The `NewBug` component should contain an `EditForm` component with with a `Model` attribute set to `AddBug`.");
            }

        }
    }
}