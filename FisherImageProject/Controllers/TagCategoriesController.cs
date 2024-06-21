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
    public class TagCategoriesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public TagCategoriesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/TagCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagCategory>>> GetTagCategorys()
        {
            return await _context.TagCategorys.ToListAsync();
        }

        // GET: api/TagCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TagCategory>> GetTagCategory(long id)
        {
            var tagCategory = await _context.TagCategorys.FindAsync(id);

            if (tagCategory == null)
            {
                return NotFound();
            }

            return tagCategory;
        }

        // PUT: api/TagCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTagCategory(long id, TagCategory tagCategory)
        {
            if (id != tagCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(tagCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagCategoryExists(id))
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

        // POST: api/TagCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TagCategory>> PostTagCategory(TagCategory tagCategory)
        {
            _context.TagCategorys.Add(tagCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTagCategory", new { id = tagCategory.Id }, tagCategory);
        }

        // DELETE: api/TagCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTagCategory(long id)
        {
            var tagCategory = await _context.TagCategorys.FindAsync(id);
            if (tagCategory == null)
            {
                return NotFound();
            }

            _context.TagCategorys.Remove(tagCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TagCategoryExists(long id)
        {
            return _context.TagCategorys.Any(e => e.Id == id);
        }
    }
}
