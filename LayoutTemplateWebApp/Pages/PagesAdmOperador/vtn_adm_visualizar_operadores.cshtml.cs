using LayoutTemplateWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using Microsoft.Extensions.DependencyInjection;

namespace LayoutTemplateWebApp.Pages.PagesAdmOperador
{
    public class vtn_adm_visualizar_operadoresModel : PageModel
    {
        private readonly GestionOperatorsContext _gestionOperatorsContext;
        public List<Operator> Results { get; set; }
        public void OnGet()
        {
        }
        public vtn_adm_visualizar_operadoresModel(GestionOperatorsContext gestionOperatorsContext) 
        {
            try 
            { 
                _gestionOperatorsContext= gestionOperatorsContext;
                Results = _gestionOperatorsContext.Operators.FromSqlRaw("EXEC ReadAllOperators").ToList();
            } catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error al traer los datos: " + ex.Message;
            }
            
        }
        public async Task OnPostEliminarOperador()
        {
            try
            {
                int idOperator = Convert.ToInt32(Request.Form["idOperator"]);
                using (var context = _gestionOperatorsContext)
                {
                    var result = context.Database.ExecuteSqlRaw("EXEC DeleteOperator {0}", idOperator);
                    TempData["ErrorMessage"] = "Operador eliminado con exito";
                    Page();

                }
                
                
            }catch(Exception ex)
            {
                TempData["ErrorMessage"] = "Error al eliminar el operador. Este se encuentra con horarios asignados.";
            }
        }

        public IActionResult OnPostActualizarOperador()
        {
            int idOperator = Convert.ToInt32(Request.Form["idOperator"]);
            return Redirect($"/AdminOperadores/Operadores/ActualizarOperador/{idOperator}");
        }
    }
}
