using Microsoft.AspNetCore.Mvc;

namespace Sobremesa.Controllers
{
    public class BaseController : Controller
    {
        protected bool IsAdmin()
        {
            return HttpContext.Session.GetString("UserRole") == "Administrador";
        }

        protected bool IsWorker()
        {
            return HttpContext.Session.GetString("UserRole") == "Trabajador";
        }
    }
}