using APIWEBGO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;

namespace APIWEBGO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestionOperators : ControllerBase
    {
        private GestionOperatorsContext _context;

        public GestionOperators(GestionOperatorsContext context)
        {
            _context = context;
        }



        // POST: api/GestionOperators/CreateOperator
        [HttpPost("CreateOperator")]
        public async Task<IActionResult> CreateOperator([FromBody] Operator newoperator)
        {
            var cellphoneParam = new SqlParameter("@cellphone", newoperator.cellphone);
            var emailParam = new SqlParameter("@email", newoperator.email);

            await _context.Database.ExecuteSqlRawAsync("CreateOperator @cellphone, @email", cellphoneParam, emailParam);
            return Ok("Operator created successfully.");
        }

        // GET: api/GestionOperators/ReadOperator?email=emailValue
        [HttpGet("ReadOperator")]
        public async Task<IActionResult> ReadOperator(string email)
        {
            var emailParam = new SqlParameter("@email", email);

            var operators = await _context.Operators.FromSqlRaw("EXEC ReadOperator @email", emailParam).ToListAsync();

            if (operators == null)
            {
                return NotFound();
            }

            return Ok(operators);
        }

        // DELETE: api/GestionOperators/DeleteOperator?email=emailValue
        [HttpDelete("DeleteOperator")]
        public async Task<IActionResult> DeleteOperator(string email)
        {
            var emailParam = new SqlParameter("@email", email);
            await _context.Database.ExecuteSqlRawAsync("DeleteOperator @email", emailParam);
            return Ok("Operator deleted successfully.");
        }

        /*
        // POST: api/GestionOperators/CreateEquipment
        [HttpPost("CreateEquipment")]
        public async Task<IActionResult> CreateEquipment([FromBody] Equipment newequipment)
        {
            // Define los parámetros para el stored procedure
            var availabilityParam = new SqlParameter("@availability", newequipment.availability);
            var nameParam = new SqlParameter("@name", newequipment.name);
            var descriptionParam = new SqlParameter("@description", newequipment.description);
            var idUserParam = new SqlParameter("@idUser", newequipment.idUser);
            var conditionParam = new SqlParameter("@condition", newequipment.condition);

            // Ejecutar el stored procedure para crear un nuevo equipo
            await _context.Database.ExecuteSqlRawAsync("CreateEquipment @availability, @name, @description, @idUser, @condition", availabilityParam, nameParam, descriptionParam, idUserParam, conditionParam);

            return Ok("Equipment created successfully.");
        }
        */
    }
}