using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luxData.small.small_wf.Utils
{
    public interface IProjectManager
    {
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

    }
    public class ProjectManager
    {
    }
}
