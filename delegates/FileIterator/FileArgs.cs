using System;

namespace delegates.FileIterator
{
    public class FileArgs : EventArgs
    {
        public FileArgs(string fileName)
        {
            FileName = fileName;
        }
        
        public string FileName { get; }
    }
}