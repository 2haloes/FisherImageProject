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
    public class ImageBookmarksController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ImageBookmarksController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ImageBookmarks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageBookmark>>> GetImageBookmarks()
        {
            return await _context.ImageBookmarks.ToListAsync();
        }

        // GET: api/ImageBookmarks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImageBookmark>> GetImageBookmark(long id)
        {
            var imageBookmark = await _context.ImageBookmarks.FindAsync(id);

            if (imageBookmark == null)
            {
                return NotFound();
            }

            return imageBookmark;
        }

        // PUT: api/ImageBookmarks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImageBookmark(long id, ImageBookmark imageBookmark)
        {
            if (id != imageBookmark.Id)
            {
                return BadRequest();
            }

            _context.Entry(imageBookmark).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageBookmarkExists(id))
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

        // POST: api/ImageBookmarks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ImageBookmark>> PostImageBookmark(ImageBookmark imageBookmark)
        {
            _context.ImageBookmarks.Add(imageBookmark);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImageBookmark", new { id = imageBookmark.Id }, imageBookmark);
        }

        // DELETE: api/ImageBookmarks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImageBookmark(long id)
        {
            var imageBookmark = await _context.ImageBookmarks.FindAsync(id);
            if (imageBookmark == null)
            {
                return NotFound();
            }

            _context.ImageBookmarks.Remove(imageBookmark);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImageBookmarkExists(long id)
        {
            return _context.ImageBookmarks.Any(e => e.Id == id);
        }
    }
}
