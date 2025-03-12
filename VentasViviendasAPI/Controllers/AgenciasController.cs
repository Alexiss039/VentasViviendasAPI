using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentasViviendasAPI.Data;
using VentasViviendasAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VentasViviendasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgenciasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AgenciasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Obtener todas las agencias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agencia>>> GetAgencias()
        {
            return await _context.Agencias.ToListAsync();
        }

        // Obtener una agencia por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Agencia>> GetAgencia(int id)
        {
            var agencia = await _context.Agencias.FindAsync(id);
            if (agencia == null) return NotFound();
            return agencia;
        }

        // Crear una agencia
        [HttpPost]
        public async Task<ActionResult<Agencia>> PostAgencia(Agencia agencia)
        {
            _context.Agencias.Add(agencia);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAgencia), new { id = agencia.Id }, agencia);
        }

        // Actualizar una agencia
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgencia(int id, Agencia agencia)
        {
            if (id != agencia.Id) return BadRequest();
            _context.Entry(agencia).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Eliminar una agencia
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgencia(int id)
        {
            var agencia = await _context.Agencias.FindAsync(id);
            if (agencia == null) return NotFound();
            _context.Agencias.Remove(agencia);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
