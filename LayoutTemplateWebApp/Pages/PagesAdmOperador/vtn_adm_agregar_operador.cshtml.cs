using LayoutTemplateWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using LayoutTemplateWebApp.Models;
using Microsoft.VisualStudio.Services.Common.Contracts;

namespace LayoutTemplateWebApp.Pages.PagesAdmOperador
{
    public class vtn_adm_agregar_operadorModel : PageModel
    {
        private readonly GestionOperatorsContext _gestionOperatorsContext;

        public vtn_adm_agregar_operadorModel(GestionOperatorsContext gestionOperatorsContext)
        {
            _gestionOperatorsContext = gestionOperatorsContext;
        }


        [BindProperty]
        public string CorreoElectronico { get; set; }

        [BindProperty]
        public int Numtelefonico { get; set; }

        [BindProperty]
        public int IdOperator { get; set; }

        
        public async Task AgregarOperador()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Crear un nuevo operador con los datos proporcionados por el usuario
                    var nuevoOperador = new Operator
                    {
                        Email = CorreoElectronico,
                        Cellphone = Numtelefonico.ToString(),
                        IdOperator = IdOperator
                    };

                    // Llamar al procedimiento almacenado para crear el operador
                    var cellphoneParam = new SqlParameter("@cellphone", nuevoOperador.Cellphone);
                    var emailParam = new SqlParameter("@email", nuevoOperador.Email);

                    await _gestionOperatorsContext.Database.ExecuteSqlRawAsync("CreateOperator @cellphone, @email", cellphoneParam, emailParam);

                    // Manejar el resultado del procedimiento almacenado
                    // Redirigir a una página de éxito, por ejemplo
                    TempData["Mensaje"] = "Operador agregado exitosamente";
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que pueda ocurrir al llamar al procedimiento almacenado
                // Redirigir a una página de error, por ejemplo
                TempData["Mensaje"] = "Error al agregar el operador";
            }
        }
    }




}
