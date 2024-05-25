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
    public class InformesController : ControllerBase
    {
        private readonly TurismoDbContext _context;

        public InformesController(TurismoDbContext context)
        {
            _context = context;
        }

        // GET: api/Informes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Informes>>> GetInformes()
        {
            return await _context.Informes.ToListAsync();
        }

        // GET: api/Informes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Informes>> GetInformes(int id)
        {
            var informes = await _context.Informes.FindAsync(id);

            if (informes == null)
            {
                return NotFound();
            }

            return informes;
        }

        // PUT: api/Informes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInformes(int id, Informes informes)
        {
            if (id != informes.InformeId)
            {
                return BadRequest();
            }

            _context.Entry(informes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InformesExists(id))
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

        // POST: api/Informes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Informes>> PostInformes(Informes informes)
        {
            _context.Informes.Add(informes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInformes", new { id = informes.InformeId }, informes);
        }

        // DELETE: api/Informes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInformes(int id)
        {
            var informes = await _context.Informes.FindAsync(id);
            if (informes == null)
            {
                return NotFound();
            }

            _context.Informes.Remove(informes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InformesExists(int id)
        {
            return _context.Informes.Any(e => e.InformeId == id);
        }
    }
}
