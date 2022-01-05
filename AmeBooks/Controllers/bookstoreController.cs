using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using AmeBooks.Models;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class bookstoreController : ControllerBase
    {
        private readonly ToDoContext _context;

        public string GetProduct { get; private set; }

        public bookstoreController(ToDoContext context)
        {
            _context = context;

            _context.todoProducts.Add(new Product {
                ID = "1",
                Name = "Book1",
                Price = 24.0,
                Amount = 10,
                Category = "Ficção",
                Image = "img1",
            });
            _context.todoProducts.Add(new Product
            {
                ID = "2",
                Name = "Book2",
                Price = 27.0,
                Amount = 13,
                Category = "Ficção",
                Image = "img2",
            });
            _context.todoProducts.Add(new Product
            {
                ID = "3",
                Name = "Book3",
                Price = 4.0,
                Amount = 8,
                Category = "Ficção",
                Image = "img3",
            });
            _context.todoProducts.Add(new Product
            {
                ID = "4",
                Name = "Book1",
                Price = 2.0,
                Amount = 17,
                Category = "Ficção",
                Image = "img4",
            });
            _context.todoProducts.Add(new Product
            {
                ID = "5",
                Name = "Book5",
                Price = 20.0,
                Amount = 7,
                Category = "Ficção",
                Image = "img5",
            });

            _context.SaveChanges();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.todoProducts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetItem(int id)
        {
            var item = await _context.todoProducts.FindAsync(id.ToString());

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.todoProducts.Add(product);

            await _context.SaveChangesAsync();

            return CreatedAtAction(GetProduct, new { id = product.ID }, product);
        }

    }
}
