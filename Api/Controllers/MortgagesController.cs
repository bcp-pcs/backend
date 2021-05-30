using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MortgagesController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public MortgagesController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Mortgages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mortgage>>> GetMortgages()
        {
            return await _context.Mortgages.ToListAsync();
        }

        // GET: api/Mortgages/5
        [HttpGet("{id:long}")]
        public async Task<ActionResult<Mortgage>> GetMortgage(long id)
        {
            var mortgage = await _context.Mortgages.FindAsync(id);

            if (mortgage == null)
            {
                return NotFound();
            }

            return mortgage;
        }

        // PUT: api/Mortgages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id:long}")]
        public async Task<IActionResult> PutMortgage(long id, Mortgage mortgage)
        {
            if (id != mortgage.Id)
            {
                return BadRequest();
            }

            _context.Entry(mortgage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MortgageExists(id))
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

        // POST: api/Mortgages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Mortgage>> PostMortgage(Mortgage mortgage)
        {
            _context.Mortgages.Add(mortgage);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMortgage), new { id = mortgage.Id }, mortgage);
        }

        // DELETE: api/Mortgages/5
        [HttpDelete("{id:long}")]
        public async Task<ActionResult<Mortgage>> DeleteMortgage(long id)
        {
            var mortgage = await _context.Mortgages.FindAsync(id);
            if (mortgage == null)
            {
                return NotFound();
            }

            _context.Mortgages.Remove(mortgage);
            await _context.SaveChangesAsync();

            return mortgage;
        }

        private bool MortgageExists(long id)
        {
            return _context.Mortgages.Any(e => e.Id == id);
        }
    }
}
