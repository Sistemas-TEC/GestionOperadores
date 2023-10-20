using LayoutTemplateWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Services.Common.Contracts;
using System.Data;

namespace LayoutTemplateWebApp.Pages.PagesAdmOperador
{
    public class vtn_adm_eliminar_operadorModel : PageModel
    {
        private readonly GestionOperatorsContext _gestionOperatorsContext;



        public vtn_adm_eliminar_operadorModel(GestionOperatorsContext gestionOperatorsContext)
        {
            _gestionOperatorsContext = gestionOperatorsContext;
            CorreoElectronico_2 = ""; // O asigna el valor predeterminado que desees
        
        }


        [BindProperty]
        public string CorreoElectronico_2 { get; set; }


        public async Task OnPostEliminarOperador()
        {
            try
            {
                if (ModelState.IsValid)
                {


                    var parameters = new SqlParameter[]
                    {
              
                        new SqlParameter("@email",CorreoElectronico_2)

                    };

                    await _gestionOperatorsContext.Database.ExecuteSqlRawAsync("EXEC DeleteOperator @email", parameters);

                    // Manejar el resultado del procedimiento almacenado
                    // Redirigir a una página de éxito, por ejemplo
                    TempData["Mensaje"] = "Operador eliminado exitosamente";
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que pueda ocurrir al llamar al procedimiento almacenado
                // Redirigir a una página de error, por ejemplo
                TempData["Mensaje"] = "Error al eliminar el operador";
            }
        }


    }
}

