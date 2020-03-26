using System;
using System.IO;
using System.Linq;
using Xunit;

namespace BugTrackerUI.Tests
{
    public static class TestHelpers
    {
        private static readonly string _projectName = "BugTrackerUI";

        public static Type GetClassType(string fullName)
        {
            return (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                    where assembly.FullName.StartsWith(_projectName)
                    from type in assembly.GetTypes()
                    where type.FullName == fullName
                    select type).FirstOrDefault();
        }

        public static string GetRootString()
        {
            return ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar;
        }
    }
}
