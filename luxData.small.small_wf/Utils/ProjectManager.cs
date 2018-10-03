using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
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


        void RestoreBackup(string path);
        void SetDefaultClassification(string path);
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
        public string ClassificationFilePath => $@"{ClassificationFolderPath}\{ClassificationFile}";
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

        public void RestoreBackup(string path)
        {
            CheckJsonFile(path);

            DeleteDbFolderContent();
            ZipFile.ExtractToDirectory(path, DbFolderPath);
        }

        /// <summary>
        /// Checks if the specified file exists and if it is a valid json file
        /// If it isn't exceptions will be thrown
        /// </summary>
        /// <param name="path"></param>
        private static void CheckJsonFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Could not find specified file");
            }
            if (Path.GetExtension(path) != ".json")
            {
                throw new ArgumentOutOfRangeException("File must be a json file");
            }
        }

        private void DeleteDbFolderContent()
        {
            DirectoryInfo di = new DirectoryInfo(DbFolderPath);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        public void SetDefaultClassification(string path)
        {
            CheckJsonFile(path);
            File.Copy(path, ClassificationFilePath, true);
        }
    }
}
