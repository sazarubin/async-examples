using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncOnly
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            var instance = new NonStatic();
            instance.VoidMethod();
            await instance.AsyncOnly();
            await instance.SingleAwait();await instance.TwoAwaits();
            Task.Run(Console.WriteLine);
            var factory = Task.Factory;
            var longRunning = factory.StartNew(Console.WriteLine,
                factory.CreationOptions | TaskCreationOptions.LongRunning);
        }
    }
}