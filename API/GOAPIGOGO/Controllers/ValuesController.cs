
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using GOAPIGOGO.Models;

namespace GOAPIGOGO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private PruebaSSLContext _pruebaSSLcontext;

        public ValuesController(PruebaSSLContext pruebaSSLcontext)
        {
            _pruebaSSLcontext = pruebaSSLcontext;
        }



        // POST: api/GestionOperators/CreateOperator
        [HttpPost("CreateOperator")]
        public async Task<IActionResult> CreateOperator([FromBody] Operator newoperator)
        {
            var cellphoneParam = new SqlParameter("@cellphone", newoperator.cellphone);
            var emailParam = new SqlParameter("@email", newoperator.email);

            await _pruebaSSLcontext.Database.ExecuteSqlRawAsync("CreateOperator @cellphone, @email", cellphoneParam, emailParam);
            return Ok("Operator created successfully.");
        }

        // GET: api/GestionOperators/ReadOperator?email=emailValue
        [HttpGet("ReadOperator")]
        public async Task<IActionResult> ReadOperator(string email)
        {
            var emailParam = new SqlParameter("@email", email);

            var operators = await _pruebaSSLcontext.Operators.FromSqlRaw("EXEC ReadOperator @email", emailParam).ToListAsync();

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
            await _pruebaSSLcontext.Database.ExecuteSqlRawAsync("DeleteOperator @email", emailParam);
            return Ok("Operator deleted successfully.");
        }


        // POST: api/GestionOperators/CreateADMOperator
        [HttpPost("CreateADMOperator")]
        public async Task<IActionResult> CreateADMOperator([FromBody] AdmOperator newADMoperator)
        {
            var cellphoneParam = new SqlParameter("@cellphone", newADMoperator.cellphone);
            var emailParam = new SqlParameter("@email", newADMoperator.email);
            var IDadmOperator = new SqlParameter("@idAdmOperator", newADMoperator.idAdmOperator);  // Corrected parameter name

            await _pruebaSSLcontext.Database.ExecuteSqlRawAsync("CreateAdmOperator @idAdmOperator, @cellphone, @email", IDadmOperator, cellphoneParam, emailParam);
            return Ok("admOperator created successfully.");
        }



        [HttpGet("ReadALLADMOperator")]
        public async Task<IActionResult> ReadALLADMOperator()
        {

            var admoperators = await _pruebaSSLcontext.AdmOperators.FromSqlRaw("EXEC ReadAllAdmOperators").ToListAsync();

            if (admoperators == null)
            {
                return NotFound();
            }

            return Ok(admoperators);
        }

       
    }
}


