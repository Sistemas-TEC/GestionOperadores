using LayoutTemplateWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LayoutTemplateWebApp.Pages.PagesAdmOperador
{
    public class vtn_adm_visualizar_horarios_operadoresModel : PageModel
    {
        private readonly GestionOperatorsContext _gestionOperatorsContext;
        public string Instalaciones { get; set; }
        public DateTime Fecha { get; set; }
        public List<GetOperatorsForFacilityOnDateResult> Results { get; set; }
        public vtn_adm_visualizar_horarios_operadoresModel(GestionOperatorsContext gestionOperatorsContext)
        {
            _gestionOperatorsContext = gestionOperatorsContext;
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

                using (var context = _gestionOperatorsContext)
                {
                    //Si despues de una generacion de contexto se cae aca, ir a GestionOperatorsContext.cs y agregar public virtual DbSet<GetOperatorsForFacilityOnDateResult> GetOperatorsForFacilityOnDateResults { get; set; } al inicio de la clase
                    Results = context.GetOperatorsForFacilityOnDateResults.FromSqlRaw("EXEC GetOperatorsForFacilityOnDate {0}, {1}", fecha, instalaciones).ToList();
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
