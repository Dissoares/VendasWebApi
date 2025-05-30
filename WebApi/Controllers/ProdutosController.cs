﻿using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(Produto produto)
        {
            _context.Produto.Add(produto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(BuscarPorId), new { id = produto.Id }, produto);
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodos()
        {
            var produtos = await _context.Produto.ToListAsync();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var produto = await _context.Produto.FindAsync(id);
            if (produto == null) return NotFound();
            return Ok(produto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtuaLIZAR(int id, Produto produto)
        {
            if (id != produto.Id) return BadRequest();

            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var produto = await _context.Produto.FindAsync(id);
            if (produto == null) return NotFound();

            _context.Produto.Remove(produto);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
