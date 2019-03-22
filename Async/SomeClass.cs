using System;
using System.Threading.Tasks;

namespace Async
{
    public class SomeClass
    {
        public async void VoidMethod()
        {
            Console.WriteLine("void");
        }

        public async Task AsyncOnly()
        {
            Console.WriteLine("only async");
        }

        public async Task SingleAwait()
        {
            Console.WriteLine("single await started");
            await Task.Delay(10);
            Console.WriteLine("single await finished");
        }

        public async Task TwoAwaits()
        {
            Console.WriteLine("two awaits started");
            await Task.Delay(10);
            Console.WriteLine("first await finished");
            await Task.Delay(10);
            Console.WriteLine("second await finished");
        }

        public async Task TwoAwaitLoops()
        {
            Console.WriteLine("two awaits started");
            for (var i = 0; i < 5; i++)
            {
                await Task.Delay(10);
            }
            Console.WriteLine("first await finished");
            for (var j = 0; j < 3; j++)
            {
                await Task.Delay(10);
            }
            Console.WriteLine("second await finished");
        }
    }
}