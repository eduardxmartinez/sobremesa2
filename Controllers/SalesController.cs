using Microsoft.AspNetCore.Mvc;

namespace Sobremesa.Controllers
{
    public class SalesController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
}
