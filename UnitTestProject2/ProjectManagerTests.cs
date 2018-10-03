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
        public void InitOnce()
        {
            Properties.Settings.Default["defaultFolder"] = TestContext.CurrentContext.TestDirectory + "\\lds_project_copy";
            Properties.Settings.Default.Save();
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

            var projectPath = Properties.Settings.Default["defaultFolder"].ToString();
            _projectManager = new ProjectManager(projectPath);
        }

        [Test]
        public void BuildNewProject_ProjectPathNotEmptyDirectory_throwException()
        {
            Assert.That(() => _projectManager.BuildNewProject(),
                Throws.Exception.TypeOf<InvalidOperationException>());

        }
    }
}
