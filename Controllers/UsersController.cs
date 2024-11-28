using Microsoft.AspNetCore.Mvc;
using Sobremesa.Data;
using Sobremesa.Models;
using System.Linq;
using BCrypt.Net;

namespace Sobremesa.Controllers
{
    public class UsersController : Controller
    {
        private readonly SobremesaContext _context;

        public UsersController(SobremesaContext context)
        {
            _context = context;
        }

        // GET: List of Users
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserRole") != "Administrador")
            {
                return RedirectToAction("Login", "Account");
            }

            var users = _context.Usuarios.ToList();
            return View(users);
        }

        // GET: Create User Form
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("UserRole") != "Administrador")
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        // POST: Create New User
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string nombre, string correo, string rol, string password)
        {
            if (ModelState.IsValid)
            {
                var user = new Usuario
                {
                    Nombre = nombre,
                    Correo = correo,
                    Rol = rol,
                    Contraseña = BCrypt.Net.BCrypt.HashPassword(password)
                };

                _context.Usuarios.Add(user);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: Edit User Password Form
        public IActionResult ChangePassword(int? id)
        {
            if (HttpContext.Session.GetString("UserRole") != "Administrador")
            {
                return RedirectToAction("Login", "Account");
            }

            if (id == null)
            {
                return NotFound();
            }

            var user = _context.Usuarios.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Update User Password
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangePassword(int id, string newPassword)
        {
            if (HttpContext.Session.GetString("UserRole") != "Administrador")
            {
                return RedirectToAction("Login", "Account");
            }

            var user = _context.Usuarios.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Contraseña = BCrypt.Net.BCrypt.HashPassword(newPassword); // Hash the new password
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        // GET: Edit User Form
        public IActionResult Edit(int? id)
        {
            if (HttpContext.Session.GetString("UserRole") != "Administrador")
            {
                return RedirectToAction("Login", "Account");
            }

            if (id == null)
            {
                return NotFound();
            }

            var user = _context.Usuarios.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Update User
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Usuario updatedUser)
        {
            if (HttpContext.Session.GetString("UserRole") != "Administrador")
            {
                return RedirectToAction("Login", "Account");
            }

            if (id != updatedUser.UsuarioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var user = _context.Usuarios.Find(id);
                if (user == null)
                {
                    return NotFound();
                }

                user.Nombre = updatedUser.Nombre;
                user.Correo = updatedUser.Correo;
                user.Rol = updatedUser.Rol;

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(updatedUser);
        }
        // GET: Confirm Deletion
        public IActionResult Delete(int? id)
        {
            if (HttpContext.Session.GetString("UserRole") != "Administrador")
            {
                return RedirectToAction("Login", "Account");
            }

            if (id == null)
            {
                return NotFound();
            }

            var user = _context.Usuarios.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Delete User
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("UserRole") != "Administrador")
            {
                return RedirectToAction("Login", "Account");
            }

            var user = _context.Usuarios.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(user);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}