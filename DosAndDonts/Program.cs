using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DosAndDonts
{
    public static class Program
    {
        private static readonly IDictionary<string, Func<Task>> _actions = new Dictionary<string, Func<Task>>
        {
            {"continuewith", Exceptions.LostOnContinueWith},
            {"thrown", Exceptions.ThrownOnAwait},
            {"exceptioncatcher", Exceptions.ExceptionCatcher},
            {"asynclock", Lock.AwaitInsideLock},
        };
        
        private static async Task Main(string[] args)
        {
            await SuperUglyCode(args);
        }

        private static async Task SuperUglyCode(string[] args)
        {
            if (args.Length == 0)
            {
                return;
            }

            if (!_actions.TryGetValue(args[0], out var action))
            {
                return;
            }

            await action();
        }
    }
}