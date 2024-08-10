using Microsoft.AspNetCore.Mvc;

namespace Asssigment.Controllers
{
    public class QuestionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
