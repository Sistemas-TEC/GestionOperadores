using LayoutTemplateWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LayoutTemplateWebApp.Pages.PagesAdmOperador
{
    public class vtn_asignar_horarioModel : PageModel
    {
        private readonly GestionOperatorsContext _gestionOperatorsContext;
        public vtn_asignar_horarioModel(GestionOperatorsContext gestionOperatorsContext)
        {
            _gestionOperatorsContext= gestionOperatorsContext;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPostAsignar() 
        {
            try
            {
                int carnet = int.Parse(Request.Form["carnet"]);
                DateTime fecha = DateTime.Parse(Request.Form["fecha"]);
                string idFacility = Request.Form["oficina"];
                TimeOnly entrada = TimeOnly.Parse(Request.Form["entrada"]);
                TimeOnly salida = TimeOnly.Parse(Request.Form["salida"]);
                int cantidad = int.Parse(Request.Form["cantsemanas"]);

                //convertir horas a tipo de dato utilizable por sql server
                TimeSpan entradaTimeSpan = TimeSpan.FromHours(entrada.Hour) + TimeSpan.FromMinutes(entrada.Minute);
                TimeSpan salidaTimeSpan = TimeSpan.FromHours(salida.Hour) + TimeSpan.FromMinutes(salida.Minute);

                using (var context = _gestionOperatorsContext)
                {
                    var result = context.Database.ExecuteSqlRaw("EXEC CreateScheduleXOperator {0}, {1}, {2}, {3}, {4}, {5}", fecha, entradaTimeSpan, salidaTimeSpan, carnet, idFacility, cantidad);
                }
            }catch(Exception ex)
            {
                TempData["ErrorMessage"] = "No se pudo asignar el horario al operador. Error: " + ex.Message;
            }
            return Page();
        }
    }
}
