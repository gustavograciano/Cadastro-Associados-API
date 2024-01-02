using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProjetoCadastroAssociado.Controllers
{
    [ApiController]
    [Route("api/associados")]
    public class AssociadoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AssociadoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/associados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Associado>>> GetAssociados()
        {
            return await _context.Associados.ToListAsync();
        }

        // GET: api/associados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Associado>> GetAssociado(int id)
        {
            var associado = await _context.Associados.FindAsync(id);

            if (associado == null)
            {
                return NotFound();
            }

            return associado;
        }

        // POST: api/associados
        [HttpPost]
        public async Task<ActionResult<Associado>> PostAssociado(Associado associado)
        {
            _context.Associados.Add(associado);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAssociado), new { id = associado.Id }, associado);
        }

        // PUT: api/associados/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssociado(int id, Associado associado)
        {
            if (id != associado.Id)
            {
                return BadRequest();
            }

            _context.Entry(associado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssociadoExists(id))
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

        // DELETE: api/associados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssociado(int id)
        {
            var associado = await _context.Associados.FindAsync(id);
            if (associado == null)
            {
                return NotFound();
            }

            _context.Associados.Remove(associado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssociadoExists(int id)
        {
            return _context.Associados.Any(e => e.Id == id);
        }
    }
}
