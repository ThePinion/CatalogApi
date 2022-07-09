using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatalogApiProject.Models;

namespace CatalogApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistRolesController : ControllerBase
    {
        private readonly RecordsContext _context;

        public ArtistRolesController(RecordsContext context)
        {
            _context = context;
        }

        // GET: api/ArtistRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtistRole>>> GetArtistRoles()
        {
          if (_context.ArtistRoles == null)
          {
              return NotFound();
          }
            return await _context.ArtistRoles.ToListAsync();
        }

        // GET: api/ArtistRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtistRole>> GetArtistRole(long id)
        {
          if (_context.ArtistRoles == null)
          {
              return NotFound();
          }
            var artistRole = await _context.ArtistRoles.FindAsync(id);

            if (artistRole == null)
            {
                return NotFound();
            }

            return artistRole;
        }

        [HttpGet("artist/{artistId}/role/{roleId}")]
        public async Task<ActionResult<ArtistRole>> GetArtistRole(long artistId, long roleId)
        {
            if (_context.Artists == null)
            {
                return NotFound();
            }
            Console.WriteLine(" " + roleId + " " + artistId);

            var selected = _context.ArtistRoles.Where(ar => ar.ArtistId == artistId && ar.RoleId == roleId);

            var found = selected.FirstOrDefault();

            if (found == null) return NotFound();

            return found;
        }

        // PUT: api/ArtistRoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtistRole(long id, ArtistRole artistRole)
        {
            if (id != artistRole.Id)
            {
                return BadRequest();
            }

            artistRole.Artist = _context.Artists.Find(artistRole.ArtistId);
            artistRole.Role = _context.Roles.Find(artistRole.RoleId);
            _context.Entry(artistRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistRoleExists(id))
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

        // POST: api/ArtistRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ArtistRole>> PostArtistRole(ArtistRole artistRole)
        {
          if (_context.ArtistRoles == null)
          {
              return Problem("Entity set 'RecordsContext.ArtistRoles'  is null.");
          }
            artistRole.Artist = _context.Artists.Find(artistRole.ArtistId);
            artistRole.Role = _context.Roles.Find(artistRole.RoleId);
            _context.ArtistRoles.Add(artistRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtistRole", new { id = artistRole.Id }, artistRole);
        }

        // DELETE: api/ArtistRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtistRole(long id)
        {
            if (_context.ArtistRoles == null)
            {
                return NotFound();
            }
            var artistRole = await _context.ArtistRoles.FindAsync(id);
            if (artistRole == null)
            {
                return NotFound();
            }

            _context.ArtistRoles.Remove(artistRole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArtistRoleExists(long id)
        {
            return (_context.ArtistRoles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
