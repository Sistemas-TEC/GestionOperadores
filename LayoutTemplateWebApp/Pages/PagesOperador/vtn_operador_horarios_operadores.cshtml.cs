using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LayoutTemplateWebApp.Pages.PagesOperador
{
    public class vtn_operador_horarios_operadoresModel : PageModel
    {
        public void OnGet()
        {
        }
        public data_horario data_mostrar = new data_horario
        {
            leccion1 = "Juan",
            leccion2 = "Mario",
            leccion3 = "Raul",
            leccion4 = "Carlos",
            leccion5 = "Jose Pablo",
            leccion6 = "Kenneth",
            leccion7 = "Maynor",
            leccion8 = "Cesar",
            leccion9 = "Allison",
            leccion10 = "Fernanda",
            leccion11 = "Kendall",
            leccion12 = "Juan",
            leccion13 = "Juan"
        };
        public class data_horario
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
}
