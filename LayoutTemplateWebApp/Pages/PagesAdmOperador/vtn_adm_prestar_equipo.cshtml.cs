using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LayoutTemplateWebApp.Pages.PagesAdmOperador
{
    public class vtn_adm_prestar_equipoModel : PageModel
    {
        public List<string> equipos { get; set; }
        public void OnGet()
        {
            equipos = new List<string>
            {
                "Cable HDMI1",
                "Proyector1",
                "Proyector2"
            };
        }
    }
}
