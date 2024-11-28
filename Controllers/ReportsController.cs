using Microsoft.AspNetCore.Mvc;

namespace Sobremesa.Controllers
{
    public class ReportsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
}
