using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace delegates.FileIterator
{
    public class FileIterator
    {
        private readonly string _directory;

        public FileIterator()
        {
            _directory = Directory.GetCurrentDirectory();
        }
        
        public FileIterator(string directory)
        {
            _directory = directory;
        }

        public event EventHandler<FileArgs> FileFound;
        
        public IEnumerable<string> Iterate(CancellationToken? token = null)
        {
            foreach (var fileName in Directory.GetFiles(_directory))
            {
                if (token?.IsCancellationRequested ?? false)
                {
                    break;
                }
                FileFound?.Invoke(this, new FileArgs(fileName));
                yield return fileName;
            }
        }
    }
}