using Microsoft.EntityFrameworkCore;
using LayoutTemplateWebApp.Models;
using Microsoft.VisualStudio.Services.Common.Contracts;
using System.Threading.Tasks;  // Agrega using para Task
using Azure.Core;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace LayoutTemplateWebApp.Pages.PagesAdmOperador
{
    public class vtn_adm_agregar_operadorModel : PageModel
    {
        private readonly GestionOperatorsContext _gestionOperatorsContext;

        public vtn_adm_agregar_operadorModel(GestionOperatorsContext gestionOperatorsContext)
        {
            _gestionOperatorsContext = gestionOperatorsContext;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAgregarOperador()  // Cambio de nombre
        {
            try
            {
                string email = Request.Form["email"];
                string cellphone = Request.Form["cellphone"];
                int id = Int32.Parse(Request.Form["id"]);  // Cambio de nombre

                using (var context = _gestionOperatorsContext)
                {
                    var result = context.Database.ExecuteSqlRaw("EXEC CreateOperator {0}, {1}, {2}", id, cellphone, email);
                }
                TempData["ErrorMessage"] = "Operador agregado exitosamente";  // Corrección de mensaje

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "No se pudo agregar el operador. Error: " + ex.Message;
            }
            return Page();
        }
    }
}
