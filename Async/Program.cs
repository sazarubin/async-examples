using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            var instance = new SomeClass();
            instance.VoidMethod();
            await instance.AsyncOnly();
            await instance.SingleAwait();await instance.TwoAwaits();
            await Task.Run(Console.WriteLine);
            var factory = Task.Factory;
            var longRunning = factory.StartNew(Console.WriteLine,
                factory.CreationOptions | TaskCreationOptions.LongRunning);
        }
    }
}