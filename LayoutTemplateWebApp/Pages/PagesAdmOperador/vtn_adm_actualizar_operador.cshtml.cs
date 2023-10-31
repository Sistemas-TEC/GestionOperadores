using LayoutTemplateWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LayoutTemplateWebApp.Pages.PagesAdmOperador
{
    public class vtn_adm_actualizar_operadorModel : PageModel
    {
        private readonly GestionOperatorsContext _gestionOperatorsContext;
        public void OnGet()
        {
        }
        public vtn_adm_actualizar_operadorModel(GestionOperatorsContext gestionOperatorsContext)
        {
            _gestionOperatorsContext= gestionOperatorsContext;
        }
        public IActionResult OnPostActualizar()
        {
            try
            {
                string email = Request.Form["email"];
                string cellphone = Request.Form["cellphone"];
                int id = Int32.Parse(Request.Form["carnet"]);

                using (var context = _gestionOperatorsContext)
                {
                    var result = context.Database.ExecuteSqlRaw("EXEC updateOperator {0}, {1}, {2}", id, cellphone, email);
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "No se pudo actualizar el operador. Error: " + ex.Message;
            }
            return Page();
        }
    }
}
