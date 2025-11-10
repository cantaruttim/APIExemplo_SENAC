using exemplo.Data;
using exemplo.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace exemplo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GastosController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public GastosController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet] // semelhante select * from <tabela>
        public async Task<IActionResult> GetAll()
        {
            var gastos = await _appDbContext.tb_gastos.ToListAsync();
            return Ok(gastos);
        }

        [HttpGet("id/{id:int}")] // semelhante select * from <tabela> where id = {id:int}
        public async Task<IActionResult> GetById(int id)
        {
            var gastos = await _appDbContext.tb_gastos.FindAsync(id);
            if (gastos == null)
            {
                return NotFound();
            }
            return Ok(gastos);
        }

        [HttpPost] // insert into tabela (colunas) values ();
        public async Task<IActionResult> Create([FromBody] Gastos model)
        {
            if (model == null)
            {
                return BadRequest("Os dados não podem ser nulos");
            }

            // add Dados
            await _appDbContext.tb_gastos.AddAsync(model);

            // commit = salvar
            await _appDbContext.SaveChangesAsync();

            // retorna Status 201
            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);

        }

        [HttpPut] // UPDATE SET 
        public async Task<IActionResult> UpdatedForms(int id, [FromBody] Gastos updatedgastos)
        {
            var gastos = await _appDbContext.tb_gastos.FindAsync(id);
            if (gastos == null)
            {
                return NotFound();
            }

            _appDbContext.Entry(gastos).CurrentValues.SetValues(updatedgastos);
            await _appDbContext.SaveChangesAsync();

            return StatusCode(201, gastos);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteRow(int id)
        {
            var gasto = await _appDbContext.tb_gastos.FindAsync(id);
            if (gasto == null)
            {
                return NotFound("Registro não Encontrado");
            }

            _appDbContext.tb_gastos.Remove(gasto);
            await _appDbContext.SaveChangesAsync();

            return Ok("Registro Deletado com Sucesso");

        }

    }
}