using Microsoft.EntityFrameworkCore;
using LayoutTemplateWebApp.Models;
using Microsoft.VisualStudio.Services.Common.Contracts;
using System.Threading.Tasks;  // Agrega using para Task
using Azure.Core;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace LayoutTemplateWebApp.Pages.PagesAdmOperador
{
    public class vtn_adm_agregar_equipoModel : PageModel
    {
        private readonly GestionOperatorsContext _gestionOperatorsContext;

        public vtn_adm_agregar_equipoModel(GestionOperatorsContext gestionOperatorsContext)
        {
            _gestionOperatorsContext = gestionOperatorsContext;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAgregarEquipo()  // Cambio de nombre
        {
            try
            {
                int idEquipment = Convert.ToInt32(Request.Form["idEquipo"]);
                bool availability = Convert.ToBoolean(Request.Form["disponibilidadEquipo"]);
                string name = Request.Form["nameEquipo"];
                string description = Request.Form["descripcionInput"];
                int idUser = 0;
                string condition = Request.Form["CondicionEquipo"];

                using (var context = _gestionOperatorsContext)
                {
                    var result = context.Database.ExecuteSqlRaw("EXEC CreateEquipment {0}, {1}, {2}, {3}, {4}, {5}", idEquipment, availability, name, description, idUser, condition);
                }
                TempData["ErrorMessage"] = "Equipo agregado exitosamente";  // Correcci�n de mensaje

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "No se pudo agregar el Equipo. Error: " + ex.Message;
            }
            return Page();
        }
    }
}

