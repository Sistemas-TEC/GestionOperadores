using LayoutTemplateWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace LayoutTemplateWebApp.Pages.PagesAdmOperador
{
    public class vtn_adm_eliminar_operadorModel : PageModel
    {
        private readonly GestionOperatorsContext _gestionOperatorsContext;

        public vtn_adm_eliminar_operadorModel(GestionOperatorsContext gestionOperatorsContext)
        {
            _gestionOperatorsContext = gestionOperatorsContext;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostEliminar()
        {
            try
            {
                int idOperador = int.Parse(Request.Form["number"]); // Parsea el valor del formulario a un entero
                using (var context = _gestionOperatorsContext)
                {
                    var result = await context.Database.ExecuteSqlRawAsync("EXEC DeleteOperator {0}", idOperador);
                }
                TempData["SuccessMessage"] = "Operador eliminado exitosamente";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "No se pudo eliminar el operador. Error: " + ex.Message;
            }
            return Page();
        }
    }
}
