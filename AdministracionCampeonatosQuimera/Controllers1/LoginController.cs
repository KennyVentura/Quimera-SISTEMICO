using AdministracionCampeonatosQuimera.Contexto;
using AdministracionCampeonatosQuimera.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AdministracionCampeonatosQuimera.Controllers
{
    public class LoginController : Controller
    {
        MyContext _context;
        public LoginController(MyContext context)
        {
            //inyeccion de dependencias
            this._context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var usuario = _context.Usuarios
                .Where(x => x.Email == email)
                .Where(x => x.Password == password)
                .FirstOrDefault();
            if(usuario != null)
            {
                await SetAuthenticationInCookie(usuario); //
                return RedirectToAction("Index", "Home");
            }                                                     
            else
            {                                      
                //mandando mensajes a la vista
                TempData["LoginError"] = "Cuenta o Password incorrectos";
                return RedirectToAction("Index", "Login");
            }  
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
        private async Task SetAuthenticationInCookie(Usuario? user)
        {
            var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.Nombre!),
                    new Claim("Cuenta", user.Email!),
                    new Claim("Id", user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Rol!.ToString()),
                };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }
    }
}
