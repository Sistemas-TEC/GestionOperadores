using LayoutTemplateWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LayoutTemplateWebApp.Pages.PagesOperador
{
    public class vtn_operador_prestar_instalacionModel : PageModel
    {
        private readonly GestionOperatorsContext gestionOperatorsContext;
        public vtn_operador_prestar_instalacionModel(GestionOperatorsContext gestionOperatorsContext)
        {
            this.gestionOperatorsContext = gestionOperatorsContext;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPostPrestar()
        {
            try
            {
                string actividad = Request.Form["actividad"];
                DateTime fecha = DateTime.Parse(Request.Form["fecha"]);
                fecha = fecha.Date;
                string idFacility = Request.Form["instalaciones"];
                TimeOnly entrada = TimeOnly.Parse(Request.Form["entrada"]);
                TimeOnly salida = TimeOnly.Parse(Request.Form["salida"]);
                TimeSpan entradaTimeSpan = new TimeSpan(entrada.Hour % 12 + (entrada.Hour >= 12 ? 12 : 0), entrada.Minute, 0);
                TimeSpan salidaTimeSpan = new TimeSpan(salida.Hour % 12 + (salida.Hour >= 12 ? 12 : 0), salida.Minute, 0);
                using (var context = this.gestionOperatorsContext)
                {
                    var result = context.Database.ExecuteSqlRaw("EXEC LendFacility {0}, {1}, {2}, {3}, {4}", idFacility, entradaTimeSpan, salidaTimeSpan, actividad, fecha);
                    //TempData["ErrorMessage"] = result;
                    Console.WriteLine(result);
                    if (result == 0)
                    {
                        TempData["ErrorMessage"] = "No se logro prestar la instalacion.";
                    }
                    else if (result == 1)
                    {
                        TempData["ErrorMessage"] = "Instalacion prestada con exito";
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
