using LayoutTemplateWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.Data.SqlClient;

namespace LayoutTemplateWebApp.Pages.PagesAdmOperador
{
    public class vtn_adm_asignar_sustitucionModel : PageModel
    {
        private readonly GestionOperatorsContext _gestionOperatorsContext;
        public vtn_adm_asignar_sustitucionModel(GestionOperatorsContext gestionOperatorsContext)
        {
            _gestionOperatorsContext = gestionOperatorsContext;
        }

        public void OnGet()
        {
        }
        public IActionResult OnPostAsignarSustitucion()
        {
            try
            {
                int carnet = int.Parse(Request.Form["carnet"]);
                DateTime fecha = DateTime.Parse(Request.Form["fecha"]);
                fecha = fecha.Date;
                string formattedDate = fecha.ToString("MM/dd/yyyy");
                string idFacility = Request.Form["oficina"];
                TimeOnly entrada = TimeOnly.Parse(Request.Form["entrada"]);
                TimeOnly salida = TimeOnly.Parse(Request.Form["salida"]);

                TimeSpan entradaTimeSpan = new TimeSpan(entrada.Hour % 12 + (entrada.Hour >= 12 ? 12 : 0), entrada.Minute, 0);
                TimeSpan salidaTimeSpan = new TimeSpan(salida.Hour % 12 + (salida.Hour >= 12 ? 12 : 0), salida.Minute, 0);
                using (var context = _gestionOperatorsContext)
                {
                    var result = context.Database.ExecuteSqlRaw("EXEC AssignOperatorSubstitution2 {0}, {1}, {2}, {3}, {4}", fecha, entradaTimeSpan, salidaTimeSpan, carnet, idFacility);
                    TempData["ErrorMessage"] = "Sustitucion asignada con exito.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "No se pudo asignar la sustitucion al operador. Error: " + ex.Message;
            }
            return Page();
        }
    }
}
