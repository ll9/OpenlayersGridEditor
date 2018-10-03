using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace luxData.small.small_wf.Utils
{
    public interface IProjectManager
    {
        string DefaultFolderKey { get; }
        string ProjectFolderPath { get; }
        string DbName { get; }
        string DbFolderPath { get; }
        string DbFilePath { get; }
        string ClassificationFolderPath { get; }
        string ClassificationFilePath { get; }
        string BackupFolderPath { get; }


        bool RestoreBackup(string path);
        bool SetDefaultClassification(string path);
        void PersistDefaultFolder();

    }

    /// <summary>
    /// Responsible for handling the project folder structure
    /// </summary>
    public class ProjectManager : IProjectManager
    {
        private const string ClassificationFile = "default.json";

        public string ProjectFolderPath
        {
            get
            {
                return Properties.Settings.Default[DefaultFolderKey].ToString();
            }
            set
            {
                Properties.Settings.Default[DefaultFolderKey] = value;
                Properties.Settings.Default.Save();
            }
        }
        public string DbName { get; }
        public string DbFolderPath { get; }
        public string DbFilePath => $@"{DbFolderPath}\{DbName}";
        public string ClassificationFolderPath { get; }
        public string ClassificationFilePath => $@"{ClassificationFolderPath}\{}"
        public string BackupFolderPath { get; }
        public string DefaultFolderKey { get; }

        public ProjectManager(string defaultFolderKey, string dbName)
        {
            DefaultFolderKey = defaultFolderKey;
            DbName = dbName;

            if (string.IsNullOrEmpty(ProjectFolderPath))
            {
                ProjectFolderPath = Application.StartupPath;
                CreateProjectFolders();
                CreateProjectFiles();

            }
        }

        private void CreateProjectFiles()
        {
            File.Create(ClassificationFilePath);
            File.Create(DbFilePath);
        }

        private void CreateProjectFolders()
        {
            Directory.CreateDirectory(BackupFolderPath);
            Directory.CreateDirectory(DbFolderPath);
            Directory.CreateDirectory(ClassificationFolderPath);
        }

        public bool RestoreBackup(string path)
        {
            throw new NotImplementedException();
        }

        public bool SetDefaultClassification(string path)
        {
            throw new NotImplementedException();
        }

        public void PersistDefaultFolder()
        {
            throw new NotImplementedException();
        }
    }
}
