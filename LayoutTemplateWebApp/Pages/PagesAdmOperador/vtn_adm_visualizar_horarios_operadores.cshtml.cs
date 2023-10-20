using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LayoutTemplateWebApp.Pages.PagesAdmOperador
{
    public class vtn_adm_visualizar_horarios_operadoresModel : PageModel
    {
        public void OnGet()
        {
        }
        public data_horario data_mostrar = new data_horario
        {
            leccion1 = "Operador2",
            leccion2 = "Operador3",
            leccion3 = "Operador1",
            leccion4 = "Operador1",
            leccion5 = "Operador4",
            leccion6 = "Operador5",
            leccion7 = "Operador2",
            leccion8 = "Operador6",
            leccion9 = "Operador1",
            leccion10 = "Operador5",
            leccion11 = "Operador4",
            leccion12 = "Operador3",
            leccion13 = "Operador2"
        };
    }
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
