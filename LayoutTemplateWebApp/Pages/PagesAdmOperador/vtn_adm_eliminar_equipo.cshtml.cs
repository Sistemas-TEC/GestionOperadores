using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace LayoutTemplateWebApp.Pages.PagesAdmOperador
{
    public class vtn_adm_eliminar_equipoModel : PageModel
    {
        public List<equipo> equipos { get; set; }
        public void OnGet()
        {
            equipos = new List<equipo>
            {
                new equipo {id = 1, name="Cable1", descripcion="Buen estadoBuen estadoBuen estadoBuen estado"}
            };
        }
    }
    public class equipo
    {
        public int id { get; set; }
        public string name { get; set; }
        public string descripcion { get; set;}
    }
}
