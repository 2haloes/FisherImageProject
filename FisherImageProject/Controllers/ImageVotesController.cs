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
    public class ImageVotesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ImageVotesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ImageVotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageVote>>> GetImageVotes()
        {
            return await _context.ImageVotes.ToListAsync();
        }

        // GET: api/ImageVotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImageVote>> GetImageVote(long id)
        {
            var imageVote = await _context.ImageVotes.FindAsync(id);

            if (imageVote == null)
            {
                return NotFound();
            }

            return imageVote;
        }

        // PUT: api/ImageVotes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImageVote(long id, ImageVote imageVote)
        {
            if (id != imageVote.Id)
            {
                return BadRequest();
            }

            _context.Entry(imageVote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageVoteExists(id))
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

        // POST: api/ImageVotes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ImageVote>> PostImageVote(ImageVote imageVote)
        {
            _context.ImageVotes.Add(imageVote);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImageVote", new { id = imageVote.Id }, imageVote);
        }

        // DELETE: api/ImageVotes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImageVote(long id)
        {
            var imageVote = await _context.ImageVotes.FindAsync(id);
            if (imageVote == null)
            {
                return NotFound();
            }

            _context.ImageVotes.Remove(imageVote);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImageVoteExists(long id)
        {
            return _context.ImageVotes.Any(e => e.Id == id);
        }
    }
}
