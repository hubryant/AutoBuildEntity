using System.Collections.Generic;
using System.IO;
using EnvDTE;
using System.Linq;

namespace AutoBuildEntity.Model
{
    public class SelectedProject
    {
        private readonly string _projectPath;
        private readonly Project _projectDte;
        private readonly List<string> _folderNames;

        public SelectedProject(string projectPath, Project projectDte, List<string> folderNames)
        {
            _projectPath = projectPath;
            _projectDte = projectDte;
            _folderNames = folderNames;
        }
        public string ProjectPath
        {
            get { return _projectPath; }
        }

        public string ProjectName
        {
            get { return Path.GetFileNameWithoutExtension(ProjectPath); }
        }

        public string ProjectDirectoryName
        {
            get { return Path.GetDirectoryName(ProjectPath); }
        }

        public Project ProjectDte
        {
            get { return _projectDte; }
        }

        public string EntityXmlPath
        {
            get { return Path.Combine(ProjectDirectoryName, Constans.EntityXml); }
        }

        public List<string> FolderNames
        {
            get
            {
                return _folderNames.Where(w => w.Contains(".") == false && w.Contains("Properties") == false).ToList();
            }
        }
    }
}
