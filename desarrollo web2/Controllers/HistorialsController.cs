using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using desarrollo_web2.Data;

namespace desarrollo_web2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialsController : ControllerBase
    {
        private readonly TurismoDbContext _context;

        public HistorialsController(TurismoDbContext context)
        {
            _context = context;
        }

        // GET: api/Historials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Historial>>> GetHistorial()
        {
            return await _context.Historial.ToListAsync();
        }

        // GET: api/Historials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Historial>> GetHistorial(int id)
        {
            var historial = await _context.Historial.FindAsync(id);

            if (historial == null)
            {
                return NotFound();
            }

            return historial;
        }

        // PUT: api/Historials/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorial(int id, Historial historial)
        {
            if (id != historial.HistorialId)
            {
                return BadRequest();
            }

            _context.Entry(historial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorialExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Historials
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Historial>> PostHistorial(Historial historial)
        {
            _context.Historial.Add(historial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistorial", new { id = historial.HistorialId }, historial);
        }

        // DELETE: api/Historials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorial(int id)
        {
            var historial = await _context.Historial.FindAsync(id);
            if (historial == null)
            {
                return NotFound();
            }

            _context.Historial.Remove(historial);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistorialExists(int id)
        {
            return _context.Historial.Any(e => e.HistorialId == id);
        }
    }
}
