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
        string DefaultFolderKey { get; set; }
        string ProjectFolderPath { get; set; }
        string DbName { get; }
        string DbFolderPath { get; set; }
        string DbFilePath { get; set; }
        string ClassificationFolderPath { get; set; }
        string ClassificationFilePath { get; set; }
        string BackupFolderPath { get; set; }


        bool RestoreBackup(string path);
        bool SetDefaultClassification(string path);
        void PersistDefaultFolder();

    }

    /// <summary>
    /// Responsible for handling the project folder structure
    /// </summary>
    public class ProjectManager : IProjectManager
    {
        public string DbFolderPath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string DbFilePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ClassificationFolderPath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ClassificationFilePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string BackupFolderPath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string DefaultFolderKey { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
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
