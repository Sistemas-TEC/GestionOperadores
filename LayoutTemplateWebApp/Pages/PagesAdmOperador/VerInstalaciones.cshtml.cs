using LayoutTemplateWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using Microsoft.Extensions.DependencyInjection;

namespace LayoutTemplateWebApp.Pages.PagesAdmOperador
{
    public class VerInstalacionesModel : PageModel
    {
        private readonly GestionOperatorsContext _gestionOperatorsContext;
        public List<SchedulexFacility> Results { get; set; }
        public void OnGet()
        {
        }
        public VerInstalacionesModel(GestionOperatorsContext gestionOperatorsContext)
        {
            try
            {
                _gestionOperatorsContext = gestionOperatorsContext;
                Results = _gestionOperatorsContext.SchedulexFacilities.FromSqlRaw("EXEC SelectAllFromSchedulexFacility").ToList();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error al traer los datos: " + ex.Message;
            }

        }
       
    }
}
