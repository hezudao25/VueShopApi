using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VueShopApi.Entities;

namespace VueShopApi.Controllers
{
    [EnableCors("any")]
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly VueShopApiContext _context;

        public ProductsController(VueShopApiContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        [HttpGet("str")]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProducts(int id)
        {
            var products = await _context.Products.FindAsync(id);

            if (products == null)
            {
                return NotFound();
            }

            return products;
        }
        //[HttpGet("{param}")]
        //public async Task<ActionResult<List<Products>>> GetProducts(string param)
        //{
        //    List<Products> products = new List<Products>();
        //       bool isNum = true;
        //    //也可以使用 int.TryParse(param)来进行判断
        //    try
        //    {
        //        Convert.ToInt32(param);
        //    }
        //    catch (Exception)
        //    {
        //        isNum = false;
        //    }
        //    if (isNum)
        //    {
        //        int id = Convert.ToInt32(param);
        //        products = await _context.Products.Where(m=>m.Id == id).ToListAsync();
        //    }
        //    else
        //    {
        //        products = await _context.Products.Where(m => m.ProductName.Contains(param)).ToListAsync();
        //    }

        //    if (products.Count <= 0)
        //    {
        //        return NotFound();
        //    }

        //    return products;
        //}
        // GET: Products/str/XXX
        [HttpGet("str/{pName}")]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts(string pName)
        {
            var products = await _context.Products.Where(m => m.ProductName.Contains(pName)).ToListAsync();

            if (products.Count <= 0)
            {
                return NotFound();
            }

            return products;
        }
        // PUT: api/Products/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(int id, Products products)
        {
            if (id != products.Id)
            {
                return BadRequest();
            }

            _context.Entry(products).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Products>> PostProducts(Products products)
        {
            _context.Products.Add(products);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducts", new { id = products.Id }, products);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Products>> DeleteProducts(int id)
        {
            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }

            _context.Products.Remove(products);
            await _context.SaveChangesAsync();

            return products;
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
