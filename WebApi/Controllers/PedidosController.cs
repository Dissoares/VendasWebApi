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
           
        }

        [HttpGet]
        public async Task<ActionResult<Pedido>> BurcarPedidoPorId(int id)
        {
            
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> AdicionarPedido(Pedido pedido)
        {
           
        }

       
    }
}

