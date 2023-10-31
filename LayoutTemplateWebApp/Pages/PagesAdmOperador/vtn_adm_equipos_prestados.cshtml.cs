using Microsoft.EntityFrameworkCore;
using LayoutTemplateWebApp.Models;
using Microsoft.VisualStudio.Services.Common.Contracts;
using System.Threading.Tasks;  // Agrega using para Task
using Azure.Core;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
    }
}
