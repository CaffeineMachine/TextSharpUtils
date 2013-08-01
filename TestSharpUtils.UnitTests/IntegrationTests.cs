using System.IO;
using System.Reflection;
using NUnit.Framework;
using TS.Utilities;

namespace TestSharpUtils.UnitTests
{
    [TestFixture]
    public class IntegrationTests
    {
        [Test]
        public void Test1()
        {
            var bd = new BookmarkDuplicator();
            var location = Assembly.GetExecutingAssembly().Location;
            location = Directory.GetParent(location).FullName;
            var document = string.Format("{0}\\TestFiles\\CHAPTER1.GENERALPROVISIONS736.pdf", location);
            bd.DuplicateBookmarksToDestinations(document);
        }
    }
}
