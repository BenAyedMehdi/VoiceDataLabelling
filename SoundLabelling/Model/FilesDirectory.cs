using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SoundLabelling
{
    class FilesDirectory
    {
        public int Count {
            get
            {
                return filesList.Count;
            }
        }

        public string fullPath { get; private set; }
        public DirectoryInfo DirectoryInfo { get; private set; }

        private List<SampleFile> filesList;


        public SampleFile this[int index]
        {
            get
            {
                return filesList[index];
            }

        }
        
        public FilesDirectory(string fullPath)
        {
            this.DirectoryInfo = new DirectoryInfo(fullPath);
            this.fullPath = fullPath;
            filesList = new List<SampleFile>();

            Load();
            Sort();
        }
        
        private void Load()
        {
            foreach (var file in DirectoryInfo.GetFiles())
            {
                filesList.Add(new SampleFile(file));
            }
        }

        public void Sort()
        {
            filesList = filesList.OrderBy(x => x.Name).ToList();
        }

        public SampleFile GetSampleByName(string text)
        {
            foreach (SampleFile item in filesList)
            {
                if (item.Name == text)
                {
                    return item;
                }
            }
            return null;
        }
        
        public SampleFile GetSample(FileInfo currentFile)
        {
            foreach (SampleFile item in filesList)
            {
                if (item.FileInfo==currentFile)
                {
                    return item;
                }
            }
            return null;
        }
        
        public List<SampleFile> GetFilesList()
        {
            return filesList;
        }
        
    }
}
