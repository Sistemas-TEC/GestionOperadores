using LayoutTemplateWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Services.Common.Contracts;
using System.Data;

namespace LayoutTemplateWebApp.Pages.PagesAdmOperador
{
    public class vtn_adm_agregar_operadorModel : PageModel
    {
        private readonly GestionOperatorsContext _gestionOperatorsContext;




        public vtn_adm_agregar_operadorModel(GestionOperatorsContext gestionOperatorsContext)
        {
            _gestionOperatorsContext = gestionOperatorsContext;
            CorreoElectronico = ""; // O asigna el valor predeterminado que desees
            Numtelefonico = 0; // O asigna el valor predeterminado que desees
            IdOperator = 0;
        }


        [BindProperty]
        public string CorreoElectronico { get; set; }

        [BindProperty]
        public int Numtelefonico { get; set; }

        [BindProperty]
        public int IdOperator { get; set; }


        public async Task OnPostAgregarOperador()
        {
            try
            {
                if (ModelState.IsValid)
                {


                    var parameters = new SqlParameter[]
                    {
                        new SqlParameter("@cellphone",Numtelefonico.ToString()),
                        new SqlParameter("@email",CorreoElectronico)

                    };

                    await _gestionOperatorsContext.Database.ExecuteSqlRawAsync("EXEC CreateOperator @cellphone, @email", parameters);

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


    } }
