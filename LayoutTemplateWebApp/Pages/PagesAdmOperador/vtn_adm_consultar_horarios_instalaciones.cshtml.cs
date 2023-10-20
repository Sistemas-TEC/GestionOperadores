using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LayoutTemplateWebApp.Pages.PagesAdmOperador
{
    public class vtn_adm_consultar_horarios_instalacionesModel : PageModel
    {
        public void OnGet()
        {
        }
        public data_horario_instalacion data_mostrar = new data_horario_instalacion
        {
            leccion1 = "Clase1",
            leccion2 = "Clase2",
            leccion3 = "Clase3",
            leccion4 = "Clase4",
            leccion5 = "Clase5",
            leccion6 = "Libre",
            leccion7 = "Clase2",
            leccion8 = "Clase1",
            leccion9 = "Clase4",
            leccion10 = "Clase7",
            leccion11 = "Clase6",
            leccion12 = "Clase1",
            leccion13 = "Clase1"
        };
    }
    public class data_horario_instalacion
    {
        public string leccion1 { get; set; }//7:30
        public string leccion2 { get; set; }//8:30
        public string leccion3 { get; set; }//9:30
        public string leccion4 { get; set; }//10:30
        public string leccion5 { get; set; }//11:30
        public string leccion6 { get; set; }//1:00
        public string leccion7 { get; set; }//2:00
        public string leccion8 { get; set; }//3:00
        public string leccion9 { get; set; }//4:00
        public string leccion10 { get; set; }//5:00
        public string leccion11 { get; set; }//6:00
        public string leccion12 { get; set; }//7:00
        public string leccion13 { get; set; }//8:00
    }
}
