﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FisherImageProject.Models;
using FisherImageProject.Shared;
using System.Reflection;

namespace FisherImageProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ImagesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Images
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Image>>> GetImages()
        {
            return await _context.Images.ToListAsync();
        }

        // GET: api/Images/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Image>> GetImage(long id)
        {
            var image = await _context.Images.FindAsync(id);

            if (image == null)
            {
                return NotFound();
            }

            return image;
        }

        // PUT: api/Images/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutImage(long id, Image image)
        {
            if (id != image.Id)
            {
                return BadRequest();
            }

            _context.Entry(image).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageExists(id))
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

        // POST: api/Images
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Image>> PostImage(Image image)
        {
            if (image.ImageData == null)
            {
                // As the image creation requires an image, a post without an image is not accepted
                return BadRequest(image);
            }

            string fileLocation = "";

            try
            {
                fileLocation = await ControllerFunctionsShared.ProcessFileUploadAsync(image.ImageData, "images");
            }
            catch (Exception ex)
            {
                // Should be replaced with throwing a server error with a message
                throw;
            }

            image.ImageData = null;
            image.ImageUrl = fileLocation;
            image.CreationTime = DateTime.UtcNow;
            _context.Images.Add(image);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImage", new { id = image.Id }, image.Id);
        }

        // PATCH: api/Images?id=5
        [HttpPatch]
        public async Task<IActionResult> PatchImage(long id, ImageUpdateDTO imageUpdateDTO)
        {
            if (id != imageUpdateDTO.Id)
            {
                return BadRequest();
            }

            //Image? currentImage = await _context.Images.FindAsync(id);
            //if (currentImage is null)
            //{
            //    return BadRequest("Image Id not found");
            //}
            ControllerFunctionsShared.FullPatchProcess(ref _context.Images, id, imageUpdateDTO);

            //_context.Entry(currentImage).State = EntityState.Modified;
            //_context.Images.Update(currentImage);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageExists(id))
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

        // DELETE: api/Images/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(long id)
        {
            var image = await _context.Images.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }

            _context.Images.Remove(image);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImageExists(long id)
        {
            return _context.Images.Any(e => e.Id == id);
        }
    }
}
