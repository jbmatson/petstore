using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Petstore.Server.Data;
using Petstore.Server.Models;

namespace Petstore.Server.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : Controller
    {

        private readonly PetstoreContext _context;

        public PetController(PetstoreContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Finds pets by their status.
        /// </summary>
        /// <param name="status">Array of statuses to filter by (e.g., available, pending, sold).</param>
        /// <returns>A list of pets matching the provided statuses.</returns>
        [HttpGet("findByStatus")]
        public async Task<ActionResult<IEnumerable<Pet>>> FindByStatus([FromQuery] string[] status)
        {
            if (status == null || status.Length == 0)
            {
                return BadRequest("At least one status must be provided.");
            }

            var pets = await _context.Pets
                .Where(p => status.Contains(p.Status))
                .ToListAsync();

            return Ok(pets);
        }
    }
}
