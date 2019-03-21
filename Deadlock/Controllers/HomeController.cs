using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Deadlock.Models;

namespace Deadlock.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()        {
            WithDeadlock().Wait();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        private async Task WithDeadlock()
        {
            Console.WriteLine("started");
            await Task.Delay(1000);
            Console.WriteLine("finished!");
        }
    }
}