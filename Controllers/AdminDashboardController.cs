using Microsoft.AspNetCore.Mvc;

namespace Sobremesa.Controllers
{
    public class AdminDashboardController : BaseController
{
    public IActionResult Index()
    {
        if (!IsAdmin())
        {
            return RedirectToAction("Login", "Account");
        }

        ViewBag.UserName = HttpContext.Session.GetString("UserName");
        return View();
    }
}
}