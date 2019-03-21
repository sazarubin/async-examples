using System;
using System.Threading.Tasks;

namespace AsyncOnly
{
    public class NonStatic
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
    }
}