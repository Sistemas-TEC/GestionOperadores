using LayoutTemplateWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LayoutTemplateWebApp.Pages.PagesAdmOperador
{
    public class vtn_adm_eliminar_equipoModel : PageModel
    {
        private readonly GestionOperatorsContext _gestionOperatorsContext;

        public vtn_adm_eliminar_equipoModel(GestionOperatorsContext gestionOperatorsContext)
        {
            _gestionOperatorsContext = gestionOperatorsContext;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostEliminarEquipo()
        {
            try
            {
                int idEquipo = int.Parse(Request.Form["numberEquipo"]); // Parsea el valor del formulario a un entero
                using (var context = _gestionOperatorsContext)
                {
                    var result = await context.Database.ExecuteSqlRawAsync("EXEC DeleteEquipment {0}", idEquipo);
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
