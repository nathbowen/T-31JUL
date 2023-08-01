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
    public class ParticipantesController : ControllerBase
    {
        private readonly T31julContext _context;

        public ParticipantesController(T31julContext context)
        {
            _context = context;
        }

        // GET: api/Participantes
        [HttpGet]
        public IEnumerable<Participantes> Get()
        {
            var participantes = new List<Participantes>
            {
                new Participantes {IdParticipante= 1, Nombre="Nathalie", Apellido="Bowen", Correo="abc", Telefono="123", Inscripciones=1}
            };

            return participantes;
        }

        // GET: api/Participantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Participantes>> GetParticipantes(int id)
        {
          if (_context.Participantes == null)
          {
              return NotFound();
          }
            var participantes = await _context.Participantes.FindAsync(id);

            if (participantes == null)
            {
                return NotFound();
            }

            return participantes;
        }

        // PUT: api/Participantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipantes(int id, Participantes participantes)
        {
            if (id != participantes.IdParticipante)
            {
                return BadRequest();
            }

            _context.Entry(participantes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantesExists(id))
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

        // POST: api/Participantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Participantes>> PostParticipantes(Participantes participantes)
        {
          if (_context.Participantes == null)
          {
              return Problem("Entity set 'T31julContext.Participantes'  is null.");
          }
            _context.Participantes.Add(participantes);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ParticipantesExists(participantes.IdParticipante))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetParticipantes", new { id = participantes.IdParticipante }, participantes);
        }

        // DELETE: api/Participantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipantes(int id)
        {
            if (_context.Participantes == null)
            {
                return NotFound();
            }
            var participantes = await _context.Participantes.FindAsync(id);
            if (participantes == null)
            {
                return NotFound();
            }

            _context.Participantes.Remove(participantes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParticipantesExists(int id)
        {
            return (_context.Participantes?.Any(e => e.IdParticipante == id)).GetValueOrDefault();
        }
    }
}
