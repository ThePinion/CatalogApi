using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatalogApiProject.Models;
using System.Net;


namespace CatalogApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly RecordsContext _context;
        
        public SearchController(RecordsContext context)
        {
            _context = context;
        }

        // GET: api/Search/Discogs/759380208759840
        [HttpGet("Discogs/{query}")]
        public async Task<ActionResult<IList<DiscogsClient.Data.Result.DiscogsSearchResult>>> GetDiscogsResult(string query)
        {
            return Ok(await Discogs.SearchQueryAsync(query));
        }
        // GET: api/Search/Discogs/release/839274398278
        [HttpGet("Discogs/release/{id}")]
        public async Task<ActionResult<Record>> GetDiscogsResult(int id)
        {
            return Ok(await Discogs.ResultQueryAsync(id));
        }
    }
}
