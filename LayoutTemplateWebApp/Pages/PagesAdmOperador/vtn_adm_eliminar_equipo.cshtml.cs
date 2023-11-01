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
        public List<Equipment> equiposLibres { get; set; }

        public vtn_adm_eliminar_equipoModel(GestionOperatorsContext gestionOperatorsContext)
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

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostEliminarEquipo()
        {
            try
            {
                int idEquipo = int.Parse(Request.Form["idEquipment"]); // Parsea el valor del formulario a un entero
                using (var context = _gestionOperatorsContext)
                {
                    var result = await context.Database.ExecuteSqlRawAsync("EXEC DeleteEquipment {0}", idEquipo);
                }
                TempData["ErrorMessage"] = "Equipo eliminado exitosamente";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "No se pudo eliminar el operador. Error: " + ex.Message;
            }
            return Page();
        }
        public async Task OnPostLiberarEquipo()
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
            Page();
        }
        public async Task OnPostPrestarEquipo()
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
            Page();
        }
    }
}
