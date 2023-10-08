using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using newprojectsas.Controllers.Models;
using newprojectsas.Data;

namespace newprojectsas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankCredController : ControllerBase
    {
        private readonly newprojectsasContext _context;

        public BankCredController(newprojectsasContext context)
        {
            _context = context;
        }

        // GET: api/BankCreds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BankCred>>> GetBankcred()
        {
            return await _context.BankCred.ToListAsync();
        }

        // GET: api/BankCreds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BankCred>> GetBankCred(int id)
        {
            var BankCred = await _context.BankCred.FindAsync(id);

            if (BankCred == null)
            {
                return NotFound();
            }

            return BankCred;
        }

        // PUT: api/BankCreds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBankCred(int id, BankCred BankCred)
        {
            if (id != BankCred.BankCredId)
            {
                return BadRequest();
            }

            _context.Entry(BankCred).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankCredExists(id))
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

        // POST: api/BankCreds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BankCred>> PostBankCred(BankCred BankCred)
        {
            _context.BankCred.Add(BankCred);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBankCred", new { id = BankCred.BankCredId }, BankCred);
        }

        // DELETE: api/BankCreds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BankCred>> DeleteBankCred(int id)
        {
            var BankCred = await _context.BankCred.FindAsync(id);
            if (BankCred == null)
            {
                return NotFound();
            }

            _context.BankCred.Remove(BankCred);
            await _context.SaveChangesAsync();

            return BankCred;
        }

        private bool BankCredExists(int id)
        {
            return _context.BankCred.Any(e => e.BankCredId == id);
        }
    }
}