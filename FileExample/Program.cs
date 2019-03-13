using System;
using System.IO;
using System.Threading.Tasks;

namespace FileExample
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            await File.WriteAllTextAsync("txt.txt", "Must write a file");
        }
    }
}