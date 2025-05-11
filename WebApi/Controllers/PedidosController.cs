using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PedidosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> BuscarTodosOsPedidos()
        {
            return await _context.Pedido
                .Include(p => p.Cliente)
                .Include(p => p.Produtos)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> BurcarPedidoPorId(int id)
        {
            var pedido = await _context.Pedido
                .Include(p => p.Cliente)
                .Include(p => p.Produtos)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pedido == null)
            {
                return NotFound();
            }

            return pedido;
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> AdicionarPedido(Pedido pedido)
        {
            _context.Pedido.Add(pedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(BurcarPedidoPorId), new { id = pedido.Id }, pedido);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, Pedido pedido)
        {
            if (id != pedido.Id)
            {
                return BadRequest();
            }

            _context.Entry(pedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Pedido.Any(e => e.Id == id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            _context.Pedido.Remove(pedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }





    }
}

