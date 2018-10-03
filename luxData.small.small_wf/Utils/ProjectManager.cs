using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace luxData.small.small_wf.Utils
{
    public interface IProjectManager
    {
        string DefaultFolderKey { get; set; }
        string DbFolderPath { get; set; }
        string DbFilePath { get; set; }
        string ClassificationFolderPath { get; set; }
        string ClassificationFilePath { get; set; }
        string BackupFolderPath { get; set; }


        bool LoadProject();
        bool LoadProject(string path);
        bool CreateProject(string path);
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

        public ProjectManager(string setting, string dbFolderPath, string dbName)
        {
            if (!LoadProject())
            {
                CreateProject(Application.StartupPath);
            }
        }

        public bool CreateProject(string path)
        {
            throw new NotImplementedException();
        }

        public bool LoadProject()
        {
            throw new NotImplementedException();
        }

        public bool LoadProject(string path)
        {
            throw new NotImplementedException();
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
