using System;
using System.Threading.Tasks;

namespace DosAndDonts
{
    public class AsyncOverSync
    {
        public static int GetTheAnswer()
        {
            return 42;
        }

        public static Task<int> GetTheAnswerAsync()
        {
            return Task.Run((Func<int>) GetTheAnswer);
        }
    }
}