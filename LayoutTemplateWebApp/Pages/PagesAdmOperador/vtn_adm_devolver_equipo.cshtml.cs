using LayoutTemplateWebApp.Pages.PagesOperador;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LayoutTemplateWebApp.Pages.PagesAdmOperador
{
    public class vtn_adm_devolver_equipoModel : PageModel
    {
        public List<string> equiposPrestados { get; set; }
        public void OnGet()
        {
            equiposPrestados = new List<string>
            {
                "Cable HDMI2",
            };
        }
    }
}
