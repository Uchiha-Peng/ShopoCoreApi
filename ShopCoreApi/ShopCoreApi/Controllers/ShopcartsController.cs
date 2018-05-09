using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopCoreApi.Data;
using ShopCoreApi.Models;

namespace ShopCoreApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class ShopcartsController : Controller
    {
        private readonly SQLiteDbContext _context;

        public ShopcartsController(SQLiteDbContext context)
        {
            _context = context;
        }

        // GET: api/Shopcarts
        [HttpGet]
        public IEnumerable<Shopcart> GetShopcart()
        {
            return _context.Shopcart;
        }

        // GET: api/Shopcarts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShopcart([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shopcart = await _context.Shopcart.SingleOrDefaultAsync(m => m.CartId == id);

            if (shopcart == null)
            {
                return NotFound();
            }

            return Ok(shopcart);
        }

        // PUT: api/Shopcarts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShopcart([FromRoute] int id, [FromBody] Shopcart shopcart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shopcart.CartId)
            {
                return BadRequest();
            }

            _context.Entry(shopcart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShopcartExists(id))
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

        // POST: api/Shopcarts
        [HttpPost]
        public async Task<IActionResult> PostShopcart([FromBody] Shopcart shopcart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Shopcart.Add(shopcart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShopcart", new { id = shopcart.CartId }, shopcart);
        }

        // DELETE: api/Shopcarts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShopcart([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shopcart = await _context.Shopcart.SingleOrDefaultAsync(m => m.CartId == id);
            if (shopcart == null)
            {
                return NotFound();
            }

            _context.Shopcart.Remove(shopcart);
            await _context.SaveChangesAsync();

            return Ok(shopcart);
        }

        private bool ShopcartExists(int id)
        {
            return _context.Shopcart.Any(e => e.CartId == id);
        }
    }
}