using Microsoft.AspNetCore.Mvc;

namespace Sobremesa.Controllers
{
    public class AlertsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
}
