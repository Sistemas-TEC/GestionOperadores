using Microsoft.EntityFrameworkCore;
using LayoutTemplateWebApp.Models;
using Microsoft.VisualStudio.Services.Common.Contracts;
using System.Threading.Tasks;  // Agrega using para Task
using Azure.Core;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace LayoutTemplateWebApp.Pages.PagesAdmOperador
{
    public class vtn_adm_reportar_equipoModel : PageModel
    {
        private readonly GestionOperatorsContext _gestionOperatorsContext;
        public vtn_adm_reportar_equipoModel(GestionOperatorsContext gestionOperatorsContext)
        {
            _gestionOperatorsContext = gestionOperatorsContext;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostReportarEquipo()  // Cambio de nombre
        {
            try
            {
                string description = Request.Form["description"];
                int idEquipo = Int32.Parse(Request.Form["id"]);  // Cambio de nombre

                using (var context = _gestionOperatorsContext)
                {
                    var result = context.Database.ExecuteSqlRaw("EXEC ChangeEquipmentDescription {0}, {1}", idEquipo, description);
                }
                TempData["SuccessMessage"] = "Operador agregado exitosamente";  // Correcci�n de mensaje

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "No se pudo agregar el operador. Error: " + ex.Message;
            }
            return Page();
        }



    }
}
