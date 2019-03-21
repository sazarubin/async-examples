using System;
using System.Threading;
using System.Threading.Tasks;

namespace DosAndDonts
{
    public class Lock
    {
        private static readonly object _lock = new object();

        public static async Task AwaitInsideLock()
        {
            await Task.WhenAll(AsyncMethodWithLogging(), AsyncMethodWithLogging());
        }

        private static async Task AsyncMethod()
        {
            try
            {
                Monitor.Enter(_lock);
                Console.WriteLine("Lock");
                await Task.Delay(1000);
            }
            finally
            {
                Console.WriteLine("Unlock");
                Monitor.Exit(_lock);
            }
        }
        
        private static async Task AsyncMethodWithLogging()
        {
            try
            {
                Monitor.Enter(_lock);
                Console.WriteLine($"Lock for thread {Thread.CurrentThread.ManagedThreadId}");
                await Task.Delay(1000);
            }
            finally
            {
                Console.WriteLine("Unlock");
                Monitor.Exit(_lock);
            }
        }
    }
}