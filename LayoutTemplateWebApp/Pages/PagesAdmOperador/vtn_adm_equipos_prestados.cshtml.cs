using Microsoft.EntityFrameworkCore;
using LayoutTemplateWebApp.Models;
using Microsoft.VisualStudio.Services.Common.Contracts;
using System.Threading.Tasks;  // Agrega using para Task
using Azure.Core;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using LayoutTemplateWebApp.Pages.PagesOperador;

namespace LayoutTemplateWebApp.Pages.PagesAdmOperador
{
    public class vtn_adm_equipos_prestadosModel : PageModel
    {
        public List<Equipment> equiposPrestados { get; set; }

        private readonly GestionOperatorsContext _gestionOperatorsContext;

        public void OnGet()
        {
        }
        public vtn_adm_equipos_prestadosModel(GestionOperatorsContext gestionOperatorsContext)
        {
            try
            {
                _gestionOperatorsContext = gestionOperatorsContext;
                equiposPrestados = _gestionOperatorsContext.Equipment.FromSqlRaw("EXEC obtenerEquiposPrestados").ToList();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error al traer los datos: " + ex.Message;
            }

        }
        public async Task OnPostEliminarEquipo()
        {
            try
            {
                int idEquipo = Convert.ToInt32(Request.Form["idEquipo"]);
                using (var context = _gestionOperatorsContext)
                {
                    var result = context.Database.ExecuteSqlRaw("EXEC DeleteEquipment {0}", idEquipo);
                    TempData["ErrorMessage"] = "Equipo eliminado con exito";
                    Page();

                }


            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error al eliminar el equipo. Este se encuentra con horarios asignados.";
            }
        }
        public async Task OnPostLiberarEquipo()
        {
            try
            {
                int idEquipment = Convert.ToInt32(Request.Form["idEquipment"]);
                bool estado = true;
                using (var context = _gestionOperatorsContext)
                {
                    var result = context.Database.ExecuteSqlRaw("EXEC sp_UpdateEquipmentAvailability {0}, {1}", idEquipment, estado);
                }
                TempData["ErrorMessage"] = "Equipo liberado con exito";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error al liberar el equipo. Este se encuentra con horarios asignados.";
            }

            Page();
        }
    }
}
