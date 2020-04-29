using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VueShopApi.Entities;
using VueShopApi.Models.ShoppingCartsDto;

namespace VueShopApi.Controllers
{
    [EnableCors("any")]
    [Route("[controller]")]
    [ApiController]
    public class ShoppingCartsController : ControllerBase
    {
        private readonly VueShopApiContext _context;

        public ShoppingCartsController(VueShopApiContext context)
        {
            _context = context;
        }

        // GET: api/ShoppingCarts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingCarts>>> GetShoppingCarts()
        {
            return await _context.ShoppingCarts.Include(m=>m.product).ToListAsync();
        }

        // GET: api/ShoppingCarts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingCarts>> GetShoppingCarts(int id)
        {
            var shoppingCarts = await _context.ShoppingCarts.FindAsync(id);

            if (shoppingCarts == null)
            {
                return NotFound();
            }

            return shoppingCarts;
        }

        // PUT: api/ShoppingCarts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoppingCarts(int id, ShoppingCarts shoppingCarts)
        {
            if (id != shoppingCarts.Id)
            {
                return BadRequest();
            }

            _context.Entry(shoppingCarts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingCartsExists(id))
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

        // POST: api/ShoppingCarts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ShoppingCarts>> PostShoppingCarts(AddCartInput aci)
        {
            ShoppingCarts shoppingCarts = new ShoppingCarts
            {
                Count = aci.Count,
                Size = aci.Size,
                ProductId = aci.ProductId
            };
            _context.ShoppingCarts.Add(shoppingCarts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShoppingCarts", new { id = shoppingCarts.Id }, shoppingCarts);
        }

        // DELETE: api/ShoppingCarts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShoppingCarts>> DeleteShoppingCarts(int id)
        {
            var shoppingCarts = await _context.ShoppingCarts.FindAsync(id);
            if (shoppingCarts == null)
            {
                return NotFound();
            }

            _context.ShoppingCarts.Remove(shoppingCarts);
            await _context.SaveChangesAsync();

            return shoppingCarts;
        }

        private bool ShoppingCartsExists(int id)
        {
            return _context.ShoppingCarts.Any(e => e.Id == id);
        }
    }
}
