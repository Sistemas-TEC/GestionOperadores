using LayoutTemplateWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LayoutTemplateWebApp.Pages.PagesOperador
{
    public class vtn_operador_prestar_equipoModel : PageModel
    {
        private readonly GestionOperatorsContext _gestionOperatorsContext;
        public List<Equipment> equiposLibres { get; set; }
        public void OnGet()
        {
        }
        public vtn_operador_prestar_equipoModel(GestionOperatorsContext gestionOperatorsContext)
        {
            try
            {
                _gestionOperatorsContext = gestionOperatorsContext;
                equiposLibres = _gestionOperatorsContext.Equipment.FromSqlRaw("EXEC ReadAllEquipment {0}", 1).ToList();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error al traer los datos: " + ex.Message;
            }
        }
        public async Task<IActionResult> OnPostLiberarEquipo()
        {
            try
            {
                int idEquipment = int.Parse(Request.Form["idEquipment"]);
                bool estado = true;
                using (var context = _gestionOperatorsContext)
                {
                    var result = context.Database.ExecuteSqlRaw("EXEC sp_UpdateEquipmentAvailability {0}, {1}", idEquipment, estado);
                }
                TempData["ErrorMessage"] = "Equipo actualizado con exito.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error al actualizar el equipo. Este se encuentra con horarios asignados.";
            }
            return Page();
        }
        public async Task<IActionResult> OnPostPrestarEquipo()
        {
            try
            {
                int idEquipment = int.Parse(Request.Form["idEquipment"]);
                bool estado = false;
                using (var context = _gestionOperatorsContext)
                {
                    var result = context.Database.ExecuteSqlRaw("EXEC sp_UpdateEquipmentAvailability {0}, {1}", idEquipment, estado);
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error al actualizar el equipo. Este se encuentra con horarios asignados.";
            }
            return Page();
        }
    }
}
