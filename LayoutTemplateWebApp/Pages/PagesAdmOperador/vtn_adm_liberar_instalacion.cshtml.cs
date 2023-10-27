using LayoutTemplateWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LayoutTemplateWebApp.Pages.PagesAdmOperador
{
    public class vtn_adm_liberar_instalacionModel : PageModel
    {
        private readonly GestionOperatorsContext _gestionOperatorsContext;
        public vtn_adm_liberar_instalacionModel(GestionOperatorsContext context)
        {
            _gestionOperatorsContext= context;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPostLiberarInstalacion()
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
                    if (result == 1)
                    {
                        TempData["ErrorMessage"] = "No se logró liberar la instalación.";
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
