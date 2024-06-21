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
    public class ImageCommentVotesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ImageCommentVotesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ImageCommentVotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageCommentVote>>> GetImageCommentVotes()
        {
            return await _context.ImageCommentVotes.ToListAsync();
        }

        // GET: api/ImageCommentVotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImageCommentVote>> GetImageCommentVote(long id)
        {
            var imageCommentVote = await _context.ImageCommentVotes.FindAsync(id);

            if (imageCommentVote == null)
            {
                return NotFound();
            }

            return imageCommentVote;
        }

        // PUT: api/ImageCommentVotes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImageCommentVote(long id, ImageCommentVote imageCommentVote)
        {
            if (id != imageCommentVote.Id)
            {
                return BadRequest();
            }

            _context.Entry(imageCommentVote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageCommentVoteExists(id))
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

        // POST: api/ImageCommentVotes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ImageCommentVote>> PostImageCommentVote(ImageCommentVote imageCommentVote)
        {
            _context.ImageCommentVotes.Add(imageCommentVote);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImageCommentVote", new { id = imageCommentVote.Id }, imageCommentVote);
        }

        // DELETE: api/ImageCommentVotes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImageCommentVote(long id)
        {
            var imageCommentVote = await _context.ImageCommentVotes.FindAsync(id);
            if (imageCommentVote == null)
            {
                return NotFound();
            }

            _context.ImageCommentVotes.Remove(imageCommentVote);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImageCommentVoteExists(long id)
        {
            return _context.ImageCommentVotes.Any(e => e.Id == id);
        }
    }
}
