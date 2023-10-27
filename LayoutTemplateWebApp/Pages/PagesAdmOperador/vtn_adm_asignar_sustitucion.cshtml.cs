using LayoutTemplateWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.Data.SqlClient;

namespace LayoutTemplateWebApp.Pages.PagesAdmOperador
{
    public class vtn_adm_asignar_sustitucionModel : PageModel
    {
        private readonly GestionOperatorsContext _gestionOperatorsContext;
        public vtn_adm_asignar_sustitucionModel(GestionOperatorsContext gestionOperatorsContext)
        {
            _gestionOperatorsContext = gestionOperatorsContext;
        }

        public void OnGet()
        {
        }
        public IActionResult OnPostAsignarSustitucion()
        {
            /*int carnet = int.Parse(Request.Form["carnet"]);
            DateTime fecha = DateTime.Parse(Request.Form["fecha"]);
            string idFacility = Request.Form["oficina"];
            TimeOnly entrada = TimeOnly.Parse(Request.Form["entrada"]);
            TimeOnly salida = TimeOnly.Parse(Request.Form["salida"]);

            //convertir horas a tipo de dato utilizable por sql server
            TimeSpan entradaTimeSpan = TimeSpan.FromHours(entrada.Hour) + TimeSpan.FromMinutes(entrada.Minute);
            TimeSpan salidaTimeSpan = TimeSpan.FromHours(salida.Hour) + TimeSpan.FromMinutes(salida.Minute);

            SqlParameter returnValue = new SqlParameter
            {
                ParameterName = "@returnValue",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            string sql = "EXEC AssignOperatorSubstitution2 @day, @beginningHour, @finishingHour, @idOperator, @idFacility, @returnValue OUTPUT";

            _gestionOperatorsContext.Database.ExecuteSqlRaw(sql,
                new SqlParameter("@day", fecha),
                new SqlParameter("@beginningHour", entrada),
                new SqlParameter("@finishingHour", salida),
                new SqlParameter("@idOperator", carnet),
                new SqlParameter("@idFacility", idFacility),
                returnValue
            );

            int resultValue = (int)returnValue.Value;

            if (resultValue == 0)
            {
                Console.WriteLine("Operation successful");
            }
            else
            {
                Console.WriteLine(carnet + " " + fecha + " " + entrada.ToString() + " " + salida.ToString());
                Console.WriteLine("Operation failed");
            }

            /*using (var context = _gestionOperatorsContext)
            {
                var result = context.Database.ExecuteSqlRaw("EXEC AssignOperatorSubstitution {0}, {1}, {2}, {3}, {4} {5}", fecha, entradaTimeSpan, salidaTimeSpan, carnet, idFacility, 0);
                TempData["ErrorMessage"] = result;
            }*/
            try
            {
                int carnet = int.Parse(Request.Form["carnet"]);
                DateTime fecha = DateTime.Parse(Request.Form["fecha"]);
                fecha = fecha.Date;
                string formattedDate = fecha.ToString("MM/dd/yyyy");
                string idFacility = Request.Form["oficina"];
                TimeOnly entrada = TimeOnly.Parse(Request.Form["entrada"]);
                TimeOnly salida = TimeOnly.Parse(Request.Form["salida"]);

                //convertir horas a tipo de dato utilizable por sql server
                //TimeSpan entradaTimeSpan = TimeSpan.FromHours(entrada.Hour) + TimeSpan.FromMinutes(entrada.Minute);
                TimeSpan entradaTimeSpan = new TimeSpan(entrada.Hour % 12 + (entrada.Hour >= 12 ? 12 : 0), entrada.Minute, 0);
                //TimeSpan salidaTimeSpan = TimeSpan.FromHours(salida.Hour) + TimeSpan.FromMinutes(salida.Minute);
                TimeSpan salidaTimeSpan = new TimeSpan(salida.Hour % 12 + (salida.Hour >= 12 ? 12 : 0), salida.Minute, 0);
                //Console.WriteLine(carnet + " " + formattedDate + " " + entradaTimeSpan.ToString() + " " + salidaTimeSpan.ToString());
                /*int carnet = 1;
                DateTime fecha = DateTime.Parse("10/26/2023");
                string idFacility = "B3-1";
                TimeSpan entrada = new TimeSpan(13, 0, 0);
                TimeSpan salida = new TimeSpan(15, 0, 0);*/
                using (var context = _gestionOperatorsContext)
                {
                    var result = context.Database.ExecuteSqlRaw("EXEC AssignOperatorSubstitution2 {0}, {1}, {2}, {3}, {4}", fecha, entradaTimeSpan, salidaTimeSpan, carnet, idFacility);
                    //TempData["ErrorMessage"] = result;
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "No se pudo asignar la sustitucion al operador. Error: " + ex.Message;
            }
            return Page();
        }
    }
}
