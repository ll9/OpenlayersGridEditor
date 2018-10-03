using luxData.small.small_wf.Utils;
using NUnit.Framework;
using System;
using System.IO;

namespace UnitTestProject2
{
    [TestFixture]
    public class ProjectManagerTests
    {
        private const string DefaultFolderKey = "defaultFolder";
        private ProjectManager _projectManager;

        [OneTimeSetUp]
        public void FixtureSetUp()
        {
            _projectManager = new ProjectManager(DefaultFolderKey, "lds.sqlite");
            var path = TestContext.CurrentContext.TestDirectory + "\\lds_project_copy";
            _projectManager.ProjectFolderPath = path;
        }

        [SetUp]
        public void Init()
        {
            var SourcePath = TestContext.CurrentContext.TestDirectory + "\\lds_project";
            var DestinationPath = TestContext.CurrentContext.TestDirectory + "\\lds_project_copy";

            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(SourcePath, "*",
                SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(SourcePath, "*.*",
                SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath), true);

            _projectManager = new ProjectManager(DefaultFolderKey, "lds.sqlite");
        }

        [Test]
        public void BuildNewProject_ProjectPathNotEmptyDirectory_throwException()
        {
            Assert.That(() => _projectManager.BuildNewProject(),
                Throws.Exception.TypeOf<InvalidOperationException>());

        }

        [Test]
        public void SaveProjectFolder_WhenCalled_PersistFolder()
        {
            _projectManager.ProjectFolderPath = "temp";

            _projectManager = new ProjectManager(DefaultFolderKey, "lds.sqlite");

            Assert.That(_projectManager.ProjectFolderPath, Is.EqualTo("temp"));
        }
    }
}
