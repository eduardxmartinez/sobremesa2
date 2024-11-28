using Microsoft.AspNetCore.Mvc;

namespace Sobremesa.Controllers
{
    public class WorkerDashboardController : BaseController
{
    public IActionResult Index()
    {
        if (!IsWorker())
        {
            return RedirectToAction("Login", "Account");
        }

        ViewBag.UserName = HttpContext.Session.GetString("UserName");
        return View();
    }
}
}