using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentasViviendasAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentasViviendasAPI.Data;

namespace VentasViviendasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViviendasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ViviendasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Obtener todas las viviendas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vivienda>>> GetViviendas()
        {
            return await _context.Viviendas.ToListAsync();
        }

        // Obtener vivienda por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Vivienda>> GetVivienda(int id)
        {
            var vivienda = await _context.Viviendas.FindAsync(id);
            if (vivienda == null)
                return NotFound();
            return vivienda;
        }

        // Insertar una nueva vivienda
        [HttpPost]
        public async Task<ActionResult<Vivienda>> PostVivienda(Vivienda vivienda)
        {
            _context.Viviendas.Add(vivienda);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVivienda), new { id = vivienda.Id }, vivienda);
        }

        // Actualizar una vivienda
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVivienda(int id, Vivienda vivienda)
        {
            if (id != vivienda.Id)
                return BadRequest();

            _context.Entry(vivienda).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Eliminar una vivienda
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVivienda(int id)
        {
            var vivienda = await _context.Viviendas.FindAsync(id);
            if (vivienda == null)
                return NotFound();

            _context.Viviendas.Remove(vivienda);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
