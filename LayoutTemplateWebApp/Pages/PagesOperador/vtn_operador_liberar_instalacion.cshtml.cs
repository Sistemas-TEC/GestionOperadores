using LayoutTemplateWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LayoutTemplateWebApp.Pages.PagesOperador
{
    public class vtn_operador_liberar_instalacionModel : PageModel
    {
        private readonly GestionOperatorsContext _gestionOperatorsContext;
        public vtn_operador_liberar_instalacionModel(GestionOperatorsContext context)
        {
            _gestionOperatorsContext = context;
        }
        public void OnGet()
        {
        }
        
        public IActionResult OnPostLiberar()
        {
            try
            {
                DateTime fecha = DateTime.Parse(Request.Form["fecha"]);
                fecha = fecha.Date;
                string idFacility = Request.Form["instalaciones"];
                TimeOnly entrada = TimeOnly.Parse(Request.Form["entrada"]);
                TimeOnly salida = TimeOnly.Parse(Request.Form["salida"]);
                TimeSpan entradaTimeSpan = new TimeSpan(entrada.Hour % 12 + (entrada.Hour >= 12 ? 12 : 0), entrada.Minute, 0);
                TimeSpan salidaTimeSpan = new TimeSpan(salida.Hour % 12 + (salida.Hour >= 12 ? 12 : 0), salida.Minute, 0);
                using (var context = _gestionOperatorsContext)
                {
                    var result = context.Database.ExecuteSqlRaw("EXEC FreeFacility {0}, {1}, {2}, {3}", idFacility, entradaTimeSpan, salidaTimeSpan, fecha);
                    //TempData["ErrorMessage"] = result;
                    if (result == 0)
                    {
                        TempData["ErrorMessage"] = "No se logro liberar la instalacion.";
                    }else
                    {
                        TempData["ErrorMessage"] = "Instalacion liberada con exito.";
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "No se pudo prestar la instalacion. Error: " + ex.Message;
            }
            return Page();
        }
    }
}
