using Microsoft.EntityFrameworkCore;
using LayoutTemplateWebApp.Models;
using Microsoft.VisualStudio.Services.Common.Contracts;
using System.Threading.Tasks;  // Agrega using para Task
using Azure.Core;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
namespace LayoutTemplateWebApp.Pages.PagesAdmOperador
{
    public class vtn_adm_prestar_equipoModel : PageModel
    {
        private readonly GestionOperatorsContext _gestionOperatorsContext;


        public int SelectedEquipmentId { get; set; }
        public List<Equipment> equiposPrestados { get; set; }

        public vtn_adm_prestar_equipoModel(GestionOperatorsContext gestionOperatorsContext)
        {
            _gestionOperatorsContext = gestionOperatorsContext;

            try
            {
                _gestionOperatorsContext = gestionOperatorsContext;
                equiposPrestados = _gestionOperatorsContext.Equipment.FromSqlRaw("EXEC GetAvailableEquipment").ToList();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error al traer los datos: " + ex.Message;
            }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostPrestarEquipo()  // Cambio de nombre
        {
            try
            {


                int idEquipo = Int32.Parse(Request.Form["SelectedEquipmentId"]);  // Cambio de nombre
                bool estado = false;

                using (var context = _gestionOperatorsContext)
                {
                    var result = context.Database.ExecuteSqlRaw("EXEC sp_UpdateEquipmentAvailability {0}, {1}", idEquipo, estado);
                }
                TempData["SuccessMessage"] = "Operador agregado exitosamente";  // Corrección de mensaje

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "No se pudo agregar el operador. Error: " + ex.Message;
            }
            return Page();
        }
    }
}
