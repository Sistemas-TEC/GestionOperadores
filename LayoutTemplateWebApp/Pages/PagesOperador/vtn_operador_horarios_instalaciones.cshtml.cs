using LayoutTemplateWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LayoutTemplateWebApp.Pages.PagesOperador
{
    public class vtn_operador_horarios_instalacionesModel : PageModel
    {
        private readonly GestionOperatorsContext _context;
        public List<GetScheduleForFacilityOnDateResult> results { get; set; }
        public vtn_operador_horarios_instalacionesModel(GestionOperatorsContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPostBuscar()
        {
            try
            {
                string instalaciones = Request.Form["instalaciones"];
                DateTime fecha = DateTime.Parse(Request.Form["fecha"]);

                using (var context = _context)
                {
                    //Si despues de una generacion de contexto se cae aca, ir a GestionOperatorsContext.cs y agregar public virtual DbSet<GetScheduleForFacilityOnDateResult> GetScheduleForFacilityOnDateResults { get; set; } al inicio de la clase
                    results = context.GetScheduleForFacilityOnDateResults.FromSqlRaw("EXEC GetScheduleForFacilityOnDate {0}, {1}", fecha, instalaciones).ToList();
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Por favor llene los campos solicitados. Error: " + ex.Message;
            }
            return Page();
        }
    }
}
