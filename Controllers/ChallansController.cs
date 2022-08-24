using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EChallan1.Web.Data;
using EChallan1.Web.Models;

namespace EChallan1.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallansController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ChallansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Challans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Challan>>> GetChallans()
        {
            return await _context.Challans.ToListAsync();
        }

        // GET: api/Challans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Challan>> GetChallan(int id)
        {
            var challan = await _context.Challans.FindAsync(id);

            if (challan == null)
            {
                return NotFound();
            }

            return challan;
        }

        // PUT: api/Challans/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChallan(int id, Challan challan)
        {
            if (id != challan.ChallanID)
            {
                return BadRequest();
            }

            _context.Entry(challan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChallanExists(id))
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

        // POST: api/Challans
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Challan>> PostChallan(Challan challan)
        {
            _context.Challans.Add(challan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChallan", new { id = challan.ChallanID }, challan);
        }

        // DELETE: api/Challans/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Challan>> DeleteChallan(int id)
        {
            var challan = await _context.Challans.FindAsync(id);
            if (challan == null)
            {
                return NotFound();
            }

            _context.Challans.Remove(challan);
            await _context.SaveChangesAsync();

            return challan;
        }

        private bool ChallanExists(int id)
        {
            return _context.Challans.Any(e => e.ChallanID == id);
        }
    }
}
