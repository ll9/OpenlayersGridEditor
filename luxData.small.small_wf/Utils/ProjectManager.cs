﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace luxData.small.small_wf.Utils
{

    /// <summary>
    /// Responsible for handling the project folder structure
    /// </summary>
    public class ProjectManager
    {
        private readonly string ClassificationFile = Properties.Settings.Default["classificationName"].ToString();
        private readonly string DbName = Properties.Settings.Default["dbName"].ToString();

        public string ProjectFolderPath { get; }
        public string DbFolderPath => $@"{ProjectFolderPath}\DB";
        public string DbFilePath => $@"{DbFolderPath}\{DbName}";
        public string BackupFolderPath => $@"{ProjectFolderPath}\BACKUP";
        public string ClassificationFolderPath => $@"{DbFolderPath}\CLASSIFICATION";
        public string ClassificationFilePath => $@"{ClassificationFolderPath}\{ClassificationFile}";

        public ProjectManager(string projectFolderPath)
        {
            ProjectFolderPath = projectFolderPath;
        }

        public void BuildNewProject()
        {
            CreateProjectFolders();
            CreateProjectFiles();
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
