using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LayoutTemplateWebApp.Pages.PagesOperador
{
    public class vtn_operador_prestar_equipoModel : PageModel
    {
        public void OnGet()
        {
        }
        public List<equipo> lista_equipos { get; set; } = new List<equipo>
        {
            new equipo {descripcion = "Cable HDMI 1", id = 1 },
            new equipo {descripcion = "Cable HDMI 2", id = 2 },
            new equipo {descripcion = "Proyector 1", id = 3 },
            new equipo {descripcion = "Proyector 2", id = 4 },
        };
    }
}
