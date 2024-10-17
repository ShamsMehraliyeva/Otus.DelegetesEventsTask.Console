using System;
using System.IO;

namespace DelegetesEventsTask
{
    public class FileSearcher
    {
        public event EventHandler<FileArgs> FileFound;
        public void Search(string directoryPath)
        { 
            if(!Directory.Exists(directoryPath))
                throw new DirectoryNotFoundException();

            var files  = Directory.GetFiles(directoryPath);
            foreach( var file in files)
            {
                if (Program.CancelSearch)
                {
                    Console.WriteLine("Поиск отменён.");
                    break;
                }
                FileFound?.Invoke(this, new FileArgs(file));
            }
        }
    }
    public class FileArgs : EventArgs
    {
        public string FileName { get; }

        public FileArgs(string fileName)
        {
            FileName = fileName;
        }
    }
}
