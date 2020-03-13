using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Mobills.Models;
using WebApi_Mobills.Repositories;

namespace WebApi_Mobills.Controllers
{
    [Route("api/Despesas")]
    [Produces("application/json")]
    public class DespesaController : Controller
    {
        private readonly IDespesaRepository _despesaRepository = new DespesaRepository();

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_despesaRepository.GetAll());
        }

        [HttpGet("Get")]
        public IActionResult Get(int id)
        {
            return Ok(_despesaRepository.Get(id));
        }

        [HttpPost("PostDespesa")]
        public IActionResult PostDespesa([FromBody] Despesa despesa)
        {
            if(despesa == null)
            {
                return BadRequest();
            }

            _despesaRepository.Create(despesa);
            return Ok();
        }

        [HttpPut("PutDespesa")]
        public IActionResult PutDespesa([FromBody] Despesa despesa)
        {
            if (despesa == null)
            {
                return BadRequest();
            }

            _despesaRepository.Update(despesa);
            return Ok();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            _despesaRepository.Delete(id);
            return Ok();
        }
    }
}
