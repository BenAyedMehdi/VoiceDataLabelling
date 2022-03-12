using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SoundLabelling
{
    class DirectoriesStorage
    {
        private List<FilesDirectory> directories;

        public int Count { get { return directories.Count; } }

        public FilesDirectory this[int index]
        {
            get
            {
                return directories[index];
            }
        }

        public DirectoriesStorage()
        {
            directories = new List<FilesDirectory>();
        }

        public void UpdateDirectory(DirectoryInfo directoryInfo)
        {
            FilesDirectory found = FindDirectory(directoryInfo);
        
            if (found != null)
            {
                directories.Remove(found);
            }

            found = new FilesDirectory(directoryInfo.FullName);

            directories.Add(found);
        }

        public FilesDirectory FindDirectory(DirectoryInfo directoryInfo)
        {
            if (directoryInfo != null)
            {
                foreach (FilesDirectory item in directories)
                {
                    if (item.DirectoryInfo.FullName == directoryInfo.FullName)
                    {
                        return item;
                    }
                }
                return null;
            }
            else
            {
                MessageBox.Show("Directory not found!");
                return null;
            }
        }
        

        internal void RenameDirectory(DirectoryInfo currentDirectory, string newPath)
        {
            FilesDirectory found = FindDirectory(currentDirectory);
            if (found != null)
            {
                directories.Remove(found);
                FilesDirectory newDirectory = new FilesDirectory(newPath);
                directories.Add(newDirectory);
            }
        }
    }
}
