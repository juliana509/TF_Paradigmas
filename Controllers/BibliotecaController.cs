using Microsoft.AspNetCore.Mvc;
using SistemaBiblioteca.Models;
using WebApplication1.Models; // Cambia "WebApplication1" por el nombre real de tu namespace
namespace SistemaBiblioteca.Controllers
{
    public class BibliotecaController : Controller
    {
        private readonly BibliotecaManager _bibliotecaManager;

        // Inyección de dependencias: ASP.NET Core le pasa la instancia única del Singleton
        public BibliotecaController(BibliotecaManager bibliotecaManager)
        {
            _bibliotecaManager = bibliotecaManager;
        }

        // Vista principal: Muestra el inventario y estado general
        public IActionResult Index()
        {
            return View(_bibliotecaManager);
        }

        // Aquí puedes agregar métodos para registrar préstamos, socios, etc.
    }
}
