using Microsoft.AspNetCore.Mvc;
using StockApi.Data;
using StockApi.Models;

namespace StockApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly StockDbContext _context;

        public ProductoController(StockDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_context.Productos.ToList());

        [HttpPost]
        public IActionResult Post([FromBody] Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Producto producto)
        {
            var prod = _context.Productos.Find(id);
            if (prod == null) return NotFound();
            prod.Nombre = producto.Nombre;
            prod.Stock = producto.Stock;
            prod.Precio = producto.Precio;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prod = _context.Productos.Find(id);
            if (prod == null) return NotFound();
            _context.Productos.Remove(prod);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
