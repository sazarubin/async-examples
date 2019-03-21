using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Deadlock2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Locking()
        {
            LockingMethod().Wait();
            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private async Task LockingMethod()
        {
            await Task.Delay(1000);
        }
    }
}