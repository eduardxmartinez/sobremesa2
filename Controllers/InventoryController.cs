using Microsoft.AspNetCore.Mvc;

namespace Sobremesa.Controllers
{
    public class InventoryController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
}
