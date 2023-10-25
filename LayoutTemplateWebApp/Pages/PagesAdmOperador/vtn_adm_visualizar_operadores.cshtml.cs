using LayoutTemplateWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LayoutTemplateWebApp.Pages.PagesAdmOperador
{
    public class vtn_adm_visualizar_operadoresModel : PageModel
    {
        private readonly GestionOperatorsContext _gestionOperatorsContext;
        public List<Operator> Results { get; set; }
        public void OnGet()
        {
        }
        public vtn_adm_visualizar_operadoresModel(GestionOperatorsContext gestionOperatorsContext) 
        {
            try 
            { 
                _gestionOperatorsContext= gestionOperatorsContext;
                Results = _gestionOperatorsContext.Operators.FromSqlRaw("EXEC ReadAllOperators").ToList();
            } catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error al traer los datos: " + ex.Message;
            }
            
        }
    }
}
