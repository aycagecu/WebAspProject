using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthorizationProject.Data;
using AuthorizationProject.Models;

namespace AuthorizationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HayvanApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HayvanApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hayvan>>> GetHayvanlar()
        {
            return await _context.Hayvanlar.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hayvan>> GetHayvan(int id)
        {
            var hayvan = await _context.Hayvanlar.FindAsync(id);

            if (hayvan == null)
            {
                return NotFound();
            }

            return hayvan;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHayvan(int id, Hayvan hayvan)
        {
            if (id != hayvan.HayvanId)
            {
                return BadRequest();
            }

            _context.Entry(hayvan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HayvanExists(id))
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


        [HttpPost]
        public async Task<ActionResult<Hayvan>> PostHayvan(Hayvan hayvan)
        {
            _context.Hayvanlar.Add(hayvan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHayvan", new { id = hayvan.HayvanId }, hayvan);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHayvan(int id)
        {
            var hayvan = await _context.Hayvanlar.FindAsync(id);
            if (hayvan == null)
            {
                return NotFound();
            }

            _context.Hayvanlar.Remove(hayvan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HayvanExists(int id)
        {
            return _context.Hayvanlar.Any(e => e.HayvanId == id);
        }
    }
}
