using System;
using System.Collections.Generic;
using System.Threading;

namespace delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var iterator = new FileIterator.FileIterator();
            
            var files = new List<string>();
            iterator.FileFound += (sender, eventArgs) => Console.WriteLine(eventArgs.FileName);
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(1));
            foreach (var file in iterator.Iterate(cts.Token))
            {
                files.Add(file);
            }
            var fileWithMaxLength = files.GetMax((string file) => file.Length);
            Console.WriteLine($"File with max length: {fileWithMaxLength}");
        }
    }
}