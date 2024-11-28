using Microsoft.AspNetCore.Mvc;
using Sobremesa.Data;
using Sobremesa.Models;
using System.Linq;

namespace Sobremesa.Controllers
{
    public class AccountController : Controller
    {
        private readonly SobremesaContext _context;

        public AccountController(SobremesaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
[HttpPost]
public IActionResult Login(string correo, string contraseña)
{
    // Find the user by email
    var user = _context.Usuarios.FirstOrDefault(u => u.Correo == correo);

    if (user != null && BCrypt.Net.BCrypt.Verify(contraseña, user.Contraseña))
    {
        // Store user information in session
        HttpContext.Session.SetString("UserName", user.Nombre);
        HttpContext.Session.SetString("UserRole", user.Rol);

        // Redirect based on role
        if (user.Rol == "Administrador")
        {
            return RedirectToAction("Index", "AdminDashboard");
        }
        else if (user.Rol == "Trabajador")
        {
            return RedirectToAction("Index", "WorkerDashboard");
        }
    }

    // If login fails
    ViewBag.Error = "Correo o contraseña incorrectos.";
    return View();
}

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}