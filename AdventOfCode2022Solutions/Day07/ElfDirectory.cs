using System.Collections.ObjectModel;

namespace AdventOfCode2022Tests.Day07
{
    public class ElfDirectory
    {
        public ReadOnlyCollection<ElfDirectory> SubDirectories => new(subDirectories);

        public ReadOnlyDictionary<string, int> FilesToSizes => new(fileNameToSize);

        public int TotalSize
        {
            get
            {
                int subdirSizes = 0;
                foreach (ElfDirectory subDir in SubDirectories)
                {
                    subdirSizes += subDir.TotalSize;
                }
                return subdirSizes + totalFilesSizeInDir;
            }
        }

        public string Name { get; internal set; }

        private int totalFilesSizeInDir = 0;

        List<ElfDirectory> subDirectories = new();

        Dictionary<string, int> fileNameToSize = new();

        public ElfDirectory(string name)
        {
            Name = name;
        }

        public bool TryToAddSubDirectory(ElfDirectory childDirectory)
        {
            if (subDirectories.Find(s => s.Name == childDirectory.Name) == null)
            {
                subDirectories.Add(childDirectory);
                return true;
            }

            return false;
        }

        public void TryToAddFile(string fileName, int size)
        {
            if (fileNameToSize.TryAdd(fileName, size))
            {
                totalFilesSizeInDir += size;
            }
        }
    }
}
