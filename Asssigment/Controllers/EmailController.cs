using Microsoft.AspNetCore.Mvc;

namespace Asssigment.Controllers
{
    public class EmailController : Controller
    {
        

        [HttpPost]
        public IActionResult BeginTest(Models.BeginTestModel model)
        {
            if (ModelState.IsValid)
            {
                
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddMinutes(30);
                Response.Cookies.Append("UserEmail", model.Email, option);

                
                return RedirectToAction("Index","Questions");
            }

          
            return View(model);
        }

        public IActionResult Questions()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
