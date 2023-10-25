using LayoutTemplateWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LayoutTemplateWebApp.Pages.PagesAdmOperador
{
    public class vtn_adm_eliminar_operadorModel : PageModel
    {
        private readonly GestionOperatorsContext _gestionOperatorsContext;
        public vtn_adm_eliminar_operadorModel(GestionOperatorsContext gestionOperatorsContext)
        {
            _gestionOperatorsContext= gestionOperatorsContext;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPostEliminar()
        {
            try
            {
                string email = Request.Form["email"];
                using (var context = _gestionOperatorsContext)
                {
                    var result = context.Database.ExecuteSqlRaw("EXEC deleteOperatorByEmail {0}", email);
                }
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = "No se pudo eliminar el operador. Error: " + ex.Message;
            }
            return Page();
        }
    }
}
