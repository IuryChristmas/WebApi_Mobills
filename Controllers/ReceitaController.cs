using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Mobills.Models;
using WebApi_Mobills.Repositories;

namespace WebApi_Mobills.Controllers
{
    [Route("api/Receitas")]
    [Produces("application/json")]
    public class ReceitaController : Controller
    {
        private readonly IReceitaRepository _receitaRepository;

        public ReceitaController()
        {
            _receitaRepository = new ReceitaRepository();
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_receitaRepository.GetAll());
        }

        [HttpGet("Get")]
        public IActionResult Get(int id)
        {
            return Ok(_receitaRepository.Get(id));
        }

        [HttpPost("PostReceita")]
        public IActionResult PostReceita([FromBody] Receita receita)
        {
            if (receita == null)
            {
                return BadRequest();
            }

            _receitaRepository.Create(receita);
            return Ok();
        }

        [HttpPut("PutReceita")]
        public IActionResult PutReceita([FromBody] Receita receita)
        {
            if (receita == null)
            {
                return BadRequest();
            }

            if (_receitaRepository.Update(receita))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            _receitaRepository.Delete(id);
            return Ok();
        }
    }
}
