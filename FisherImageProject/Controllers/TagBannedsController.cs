using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FisherImageProject.Models;

namespace FisherImageProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagBannedsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public TagBannedsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/TagBanneds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagBanned>>> GetTagBanneds()
        {
            return await _context.TagBanneds.ToListAsync();
        }

        // GET: api/TagBanneds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TagBanned>> GetTagBanned(long id)
        {
            var tagBanned = await _context.TagBanneds.FindAsync(id);

            if (tagBanned == null)
            {
                return NotFound();
            }

            return tagBanned;
        }

        // PUT: api/TagBanneds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTagBanned(long id, TagBanned tagBanned)
        {
            if (id != tagBanned.Id)
            {
                return BadRequest();
            }

            _context.Entry(tagBanned).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagBannedExists(id))
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

        // POST: api/TagBanneds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TagBanned>> PostTagBanned(TagBanned tagBanned)
        {
            _context.TagBanneds.Add(tagBanned);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTagBanned", new { id = tagBanned.Id }, tagBanned);
        }

        // DELETE: api/TagBanneds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTagBanned(long id)
        {
            var tagBanned = await _context.TagBanneds.FindAsync(id);
            if (tagBanned == null)
            {
                return NotFound();
            }

            _context.TagBanneds.Remove(tagBanned);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TagBannedExists(long id)
        {
            return _context.TagBanneds.Any(e => e.Id == id);
        }
    }
}
