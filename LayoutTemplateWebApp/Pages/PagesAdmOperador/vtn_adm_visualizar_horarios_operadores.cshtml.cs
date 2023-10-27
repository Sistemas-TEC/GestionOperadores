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

        public data_horario data_mostrar = new data_horario
        {
            leccion1 = "Operador2",
            leccion2 = "Operador3",
            leccion3 = "Operador1",
            leccion4 = "Operador1",
            leccion5 = "Operador4",
            leccion6 = "Operador5",
            leccion7 = "Operador2",
            leccion8 = "Operador6",
            leccion9 = "Operador1",
            leccion10 = "Operador5",
            leccion11 = "Operador4",
            leccion12 = "Operador3",
            leccion13 = "Operador2"
        };
    }
    public class data_horario
    {
        public string leccion1 { get; set; }//7:30
        public string leccion2 { get; set; }//8:30
        public string leccion3 { get; set; }//9:30
        public string leccion4 { get; set; }//10:30
        public string leccion5 { get; set; }//11:30
        public string leccion6 { get; set; }//1:00
        public string leccion7 { get; set; }//2:00
        public string leccion8 { get; set; }//3:00
        public string leccion9 { get; set; }//4:00
        public string leccion10 { get; set; }//5:00
        public string leccion11 { get; set; }//6:00
        public string leccion12 { get; set; }//7:00
        public string leccion13 { get; set; }//8:00
    }
}
