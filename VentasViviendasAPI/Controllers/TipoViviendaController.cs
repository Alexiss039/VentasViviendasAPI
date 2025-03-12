using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentasViviendasAPI.Data;
using VentasViviendasAPI.Models;

namespace VentasViviendasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoViviendaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TipoViviendaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoVivienda>>> GetTiposVivienda()
        {
            return await _context.TiposVivienda.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoVivienda>> GetTipoVivienda(int id)
        {
            var tipo = await _context.TiposVivienda.FindAsync(id);
            if (tipo == null) return NotFound();
            return tipo;
        }

        [HttpPost]
        public async Task<ActionResult<TipoVivienda>> PostTipoVivienda(TipoVivienda tipo)
        {
            _context.TiposVivienda.Add(tipo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTipoVivienda), new { id = tipo.Id }, tipo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoVivienda(int id, TipoVivienda tipo)
        {
            if (id != tipo.Id) return BadRequest();
            _context.Entry(tipo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoVivienda(int id)
        {
            var tipo = await _context.TiposVivienda.FindAsync(id);
            if (tipo == null) return NotFound();
            _context.TiposVivienda.Remove(tipo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
