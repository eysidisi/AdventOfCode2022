namespace AdventOfCode2022Tests.Day07
{
    public class CLI
    {
        const int totalCapacity = 70000000;

        const int requiredCapacityForUpdate = 30000000;

        public ElfDirectory CurrentDirectory => directoryStack.Peek();

        private Stack<ElfDirectory> directoryStack = new();

        private ElfDirectory rootDirectory;

        public CLI()
        {
            rootDirectory = new ElfDirectory("/");
            directoryStack.Push(rootDirectory);
        }

        public void ExecuteCommandLines(string[] commandLines)
        {
            foreach (string command in commandLines)
            {
                if (command.Split(" ")[1] == "cd")
                {
                    if (command.Split(" ")[2] == "..")
                    {
                        directoryStack.Pop();
                    }

                    else
                    {
                        string directoyName = command.Split(" ")[2];

                        if (directoyName == "/")
                            continue;

                        ElfDirectory directoryToGoIn = CurrentDirectory.SubDirectories.
                            First(d => d.Name == directoyName);
                        directoryStack.Push(directoryToGoIn);
                    }
                }

                else if (command.Split(" ")[1] == "ls")
                {

                }

                else if (command.Split(" ")[0] == "dir")
                {
                    TryToCreateNewDirectory(command);
                }

                else
                {
                    TryToAddFile(command);
                }
            }
        }
        public int FindTotalSizeOfDirectoriesLessThan(int maxSize)
        {
            Queue<ElfDirectory> elfDirectoryQueue = new();
            elfDirectoryQueue.Enqueue(rootDirectory);
            int totalSize = 0;

            while (elfDirectoryQueue.Count > 0)
            {
                ElfDirectory currentDirectory = elfDirectoryQueue.Dequeue();
                if (currentDirectory.TotalSize <= maxSize)
                    totalSize += currentDirectory.TotalSize;
                currentDirectory.SubDirectories.ToList().
                    ForEach(x => { elfDirectoryQueue.Enqueue(x); });
            }

            return totalSize;
        }

        private void TryToCreateNewDirectory(string command)
        {
            string newDirName = command.Split(" ")[1];
            ElfDirectory newDir = new(newDirName);

            if (directoryStack.Count > 0)
            {
                directoryStack.Peek().TryToAddSubDirectory(newDir);
            }
        }

        private void TryToAddFile(string command)
        {
            int fileSize = int.Parse(command.Split(" ")[0]);
            string fileName = command.Split(" ")[1];

            CurrentDirectory.TryToAddFile(fileName, fileSize);
        }

        public int FindSmallestSizeToDeleteForUpdate()
        {
            int minCapacityToDelete = requiredCapacityForUpdate - (totalCapacity - rootDirectory.TotalSize);

            return FindSmallestDirectoryWithAtLeastCapacity(minCapacityToDelete).TotalSize;
        }

        private ElfDirectory FindSmallestDirectoryWithAtLeastCapacity(int capacityToDelete)
        {
            Queue<ElfDirectory> elfDirectoryQueue = new();
            elfDirectoryQueue.Enqueue(rootDirectory);
            ElfDirectory directoryToDelete = rootDirectory;

            while (elfDirectoryQueue.Count > 0)
            {
                ElfDirectory currentDirectory = elfDirectoryQueue.Dequeue();

                if (currentDirectory.TotalSize >= capacityToDelete &&
                    currentDirectory.TotalSize < directoryToDelete.TotalSize)
                    directoryToDelete = currentDirectory;

                currentDirectory.SubDirectories.ToList().
                    ForEach(x => { elfDirectoryQueue.Enqueue(x); });
            }

            return directoryToDelete;
        }
    }
}
