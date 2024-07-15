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
    public class ImageCommentsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ImageCommentsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ImageComments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageComment>>> GetImageComments()
        {
            return await _context.ImageComments.ToListAsync();
        }

        // GET: api/ImageComments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImageComment>> GetImageComment(long id)
        {
            var imageComment = await _context.ImageComments.FindAsync(id);

            if (imageComment == null)
            {
                return NotFound();
            }

            return imageComment;
        }

        // PUT: api/ImageComments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImageComment(long id, ImageComment imageComment)
        {
            if (id != imageComment.Id)
            {
                return BadRequest();
            }

            _context.Entry(imageComment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageCommentExists(id))
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

        // POST: api/ImageComments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ImageComment>> PostImageComment(ImageComment imageComment)
        {
            _context.ImageComments.Add(imageComment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImageComment", new { id = imageComment.Id }, imageComment);
        }

        // PATCH: api/ImageComments?id=5
        [HttpPatch]
        public async Task<IActionResult> PatchImageComment(long id, ImageComment imageComment)
        {
            if (id != imageComment.Id)
            {
                return BadRequest();
            }

            _context.Entry(imageComment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageCommentExists(id))
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

        // DELETE: api/ImageComments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImageComment(long id)
        {
            var imageComment = await _context.ImageComments.FindAsync(id);
            if (imageComment == null)
            {
                return NotFound();
            }

            _context.ImageComments.Remove(imageComment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImageCommentExists(long id)
        {
            return _context.ImageComments.Any(e => e.Id == id);
        }
    }
}
