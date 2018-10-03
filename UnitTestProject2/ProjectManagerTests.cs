using luxData.small.small_wf.Utils;
using NUnit.Framework;
using System;

namespace UnitTestProject2
{
    [TestFixture]
    public class ProjectManagerTests
    {
        private const string DefaultFolderKey = "defaultFolder";
        private ProjectManager _projectManager;

        [SetUp]
        public void Init()
        {
            _projectManager = new ProjectManager(DefaultFolderKey, "lds.sqlite");
            _projectManager.ProjectFolderPath = "";
            _projectManager = new ProjectManager(DefaultFolderKey, "lds.sqlite");
        }

        [Test]
        public void TestMethod1()
        {
            Assert.That(3, Is.EqualTo(3));
        }
    }
}
