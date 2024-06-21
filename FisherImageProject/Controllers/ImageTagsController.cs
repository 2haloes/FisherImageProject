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
    public class ImageTagsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ImageTagsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ImageTags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageTag>>> GetImageTags()
        {
            return await _context.ImageTags.ToListAsync();
        }

        // GET: api/ImageTags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImageTag>> GetImageTag(long id)
        {
            var imageTag = await _context.ImageTags.FindAsync(id);

            if (imageTag == null)
            {
                return NotFound();
            }

            return imageTag;
        }

        // PUT: api/ImageTags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImageTag(long id, ImageTag imageTag)
        {
            if (id != imageTag.Id)
            {
                return BadRequest();
            }

            _context.Entry(imageTag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageTagExists(id))
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

        // POST: api/ImageTags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ImageTag>> PostImageTag(ImageTag imageTag)
        {
            _context.ImageTags.Add(imageTag);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImageTag", new { id = imageTag.Id }, imageTag);
        }

        // DELETE: api/ImageTags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImageTag(long id)
        {
            var imageTag = await _context.ImageTags.FindAsync(id);
            if (imageTag == null)
            {
                return NotFound();
            }

            _context.ImageTags.Remove(imageTag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImageTagExists(long id)
        {
            return _context.ImageTags.Any(e => e.Id == id);
        }
    }
}
