using LayoutTemplateWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace LayoutTemplateWebApp.Pages.PagesAdmOperador
{
    public class vtn_admin_prestar_instalacionModel : PageModel
    {
        private readonly GestionOperatorsContext _gestionOperatorsContext;
        public vtn_admin_prestar_instalacionModel(GestionOperatorsContext gestionOperatorsContext)
        {
            _gestionOperatorsContext = gestionOperatorsContext;
        }

        public void OnGet()
        {
        }
        public IActionResult OnPostPrestarInstalacion()
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
                using (var context = _gestionOperatorsContext)
                {
                    var result = context.Database.ExecuteSqlRaw("EXEC LendFacility {0}, {1}, {2}, {3}, {4}", idFacility,entradaTimeSpan,salidaTimeSpan,actividad,fecha);
                    //TempData["ErrorMessage"] = result;
                    Console.WriteLine(result);
                    if (result == 0)
                    {
                        TempData["ErrorMessage"] = "No se logro prestar la instalacion.";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Instalacion prestada con exito.";
                    }
                }
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = "No se pudo prestar la instalacion. Error: " + ex.Message;
            }
            return Page();
        }
    }
}
