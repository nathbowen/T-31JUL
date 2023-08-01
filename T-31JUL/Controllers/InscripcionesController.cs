using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T_31JUL.Data;
using T_31JUL.Model;

namespace T_31JUL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscripcionesController : ControllerBase
    {
        private readonly T31julContext _context;

        public InscripcionesController(T31julContext context)
        {
            _context = context;
        }

        // GET: api/Inscripciones
        public IEnumerable<Talleres> Get()
        {
            var talleres = new List<Talleres>
            {
                new Inscripciones { IdInscripcion=1, IdParticipante=1, IdTaller=1, FechaInscripcion=new DateTime(2023, 08, 31), Asistencia=1, IdTallerNavigation=1, IdParticipanteNavigation=1 }
            };

            return talleres;
        }

        // GET: api/Inscripciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inscripciones>> GetInscripcione(int id)
        {
          if (_context.Inscripciones == null)
          {
              return NotFound();
          }
            var inscripcione = await _context.Inscripciones.FindAsync(id);

            if (inscripcione == null)
            {
                return NotFound();
            }

            return inscripcione;
        }

        // PUT: api/Inscripciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInscripcione(int id, Inscripciones inscripcione)
        {
            if (id != inscripcione.IdInscripcion)
            {
                return BadRequest();
            }

            _context.Entry(inscripcione).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InscripcioneExists(id))
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

        // POST: api/Inscripciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Inscripciones>> PostInscripcione(Inscripciones inscripcione)
        {
          if (_context.Inscripciones == null)
          {
              return Problem("Entity set 'T31julContext.Inscripciones'  is null.");
          }
            _context.Inscripciones.Add(inscripcione);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InscripcioneExists(inscripcione.IdInscripcion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInscripcione", new { id = inscripcione.IdInscripcion }, inscripcione);
        }

        // DELETE: api/Inscripciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInscripcione(int id)
        {
            if (_context.Inscripciones == null)
            {
                return NotFound();
            }
            var inscripcione = await _context.Inscripciones.FindAsync(id);
            if (inscripcione == null)
            {
                return NotFound();
            }

            _context.Inscripciones.Remove(inscripcione);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InscripcioneExists(int id)
        {
            return (_context.Inscripciones?.Any(e => e.IdInscripcion == id)).GetValueOrDefault();
        }
    }
}
