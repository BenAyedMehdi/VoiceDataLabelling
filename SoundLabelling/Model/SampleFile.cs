using System;
using System.IO;

namespace SoundLabelling
{
    class SampleFile
    {
        public FileInfo FileInfo { get; private set; }
        
        public SampleFile(FileInfo fileInfo)
        {
            this.FileInfo = fileInfo;
        }

        public bool IsUnacceptable()
        {
            string filePath = ParentDirectoryPath + Name;
            string fileName= Path.GetFileNameWithoutExtension(filePath);
            return fileName.EndsWith("_u");
        }

        public string ParentDirectoryPath
        {
            get
            {
                return FileInfo.Directory.FullName;
            }
        }

        public string Name
        {
            get
            {
                return FileInfo.Name;
            }
        }

        public string Extension
        {
            get
            {
                return FileInfo.Extension;
            }
        }

        public string NameWithoutExtention()
        {
            return Path.GetFileNameWithoutExtension(ParentDirectoryPath + "\\" + Name);
        }

        public string FullPath()
        {
            return string.Format("{0}\\{1}", ParentDirectoryPath, FileInfo.Name);
        }

        internal string NewUnacceptableName()
        {
            return ParentDirectoryPath + "\\" + NameWithoutExtention() + "_u" + Extension;
        }

        public string NewPathAndName(string newPath, string newName)
        {
            return string.Format("{0}\\{1}{2}", newPath, newName, Extension);
        }

        public string NewNameWithPath(string newName)
        {
            return string.Format("{0}\\{1}{2}", FileInfo.DirectoryName, newName, Extension);
        }

        public string UnacceptableName()
        {
            return string.Format("{0}\\{1}{2}",
                FileInfo.DirectoryName,
                FileInfo.Name.EndsWith("_u") ? FileInfo.Name : FileInfo.Name + "_u",
                Extension);
        }
    }
}
