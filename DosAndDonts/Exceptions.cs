using System;
using System.Threading.Tasks;

namespace DosAndDonts
{
    public static class Exceptions
    {
        public static Task LostOnContinueWith()
        {
            Task.Run(() => GetCurrentTemperature("Moscow"))
                .ContinueWith(WriteToOutput);
            return Task.Delay(5000);
        }

        private static int GetCurrentTemperature(string location)
        {
            if (location == "Moscow")
            {
                return 10;
            }
            throw new ArgumentException($"Unknown location {location}", nameof(location));
        }

        private static void WriteToOutput(Task<int> temperature)
        {
            if (temperature.Exception != null)
            {
                throw temperature.Exception;
            }
        
            if (temperature.IsCompletedSuccessfully)
            {
                Console.WriteLine($"Requested temperature is {temperature.Result}");
            }
        }

        public static async Task ThrownOnAwait()
        {
            var result = Task.Run(() => GetCurrentTemperature("Moscow Area"));
            await result;
            WriteToOutput(result);
        }

        public static async Task ExceptionCatcher()
        {
            try
            {
                SomeMethod();
                await Task.Delay(5000);
                Console.WriteLine("Everything is fine");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Caught an exception for you: {e}");
            }
        }

        private static async void SomeMethod()
        {
            await Task.Delay(1000);
            throw new Exception("You cannot catch me!");
        }
    }
}