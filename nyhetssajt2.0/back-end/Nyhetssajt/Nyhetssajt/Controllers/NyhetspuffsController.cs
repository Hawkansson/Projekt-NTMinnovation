using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nyhetssajt.Data;
using Nyhetssajt.Models;

namespace Nyhetssajt.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class NyhetspuffsController : ControllerBase
    {
        private readonly NyhetspuffsContext _context;
        private readonly IDataRepository<Nyhetspuff> _repo;
        public NyhetspuffsController(NyhetspuffsContext context, IDataRepository<Nyhetspuff> repo)
        {
            _context = context;
            _repo = repo;
        }

        // GET: api/Nyhetspuffs
        [HttpGet]
        public IEnumerable<Nyhetspuff> GetNyhetspuff()
        {
            return _context.Nyhetspuff.OrderByDescending(p => p.GuId);
        }

        // GET: api/Nyhetspuffs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNyhetspuff([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
              return BadRequest(ModelState);
            }
            var nyhetspuff = await _context.Nyhetspuff.FindAsync(id);

            if (nyhetspuff == null)
            {
                return NotFound();
            }

            return Ok(nyhetspuff);
        }

        // PUT: api/Nyhetspuffs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNyhetspuff([FromRoute] int id, [FromBody] Nyhetspuff nyhetspuff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if ( id != nyhetspuff.GuId)
            {
              return BadRequest();
            }

            _context.Entry(nyhetspuff).State = EntityState.Modified;

            try
            {
                _repo.Update(nyhetspuff);
                var save = await _repo.SaveAsync(nyhetspuff);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NyhetspuffExists(id))
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

        // POST: api/Nyhetspuffs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<IActionResult> PostNyhetspuff([FromBody] Nyhetspuff nyhetspuff)
        {
          if(!ModelState.IsValid)
          {
            return BadRequest(ModelState);
          }

          _repo.Add(nyhetspuff);
          var save = await _repo.SaveAsync(nyhetspuff);
          
          return CreatedAtAction("GetNyhetspuff", new { id = nyhetspuff.GuId }, nyhetspuff);
        }

        // DELETE: api/Nyhetspuffs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Nyhetspuff>> DeleteNyhetspuff(int id)
        {
            if(!ModelState.IsValid)
            {
              return BadRequest(ModelState);
            }

            var nyhetspuff = await _context.Nyhetspuff.FindAsync(id);
            if (nyhetspuff == null)
            {
                return NotFound();
            }


            _repo.Delete(nyhetspuff);
            var save = await _repo.SaveAsync(nyhetspuff);

            return Ok(nyhetspuff);
        }

        private bool NyhetspuffExists(int id)
        {
            return _context.Nyhetspuff.Any(e => e.GuId == id);
        }
    }
}
