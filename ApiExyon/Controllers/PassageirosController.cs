using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiExyon.Data;
using ApiExyon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiExyon.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassageirosController : ControllerBase
    {
        private readonly DataContext _context;

        public PassageirosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Passageiro>>> Get(
            [FromServices] DataContext context)
        {
            var passageiros = await context.Passageiros.AsNoTracking().ToListAsync();
            return Ok(passageiros);
        }

        [HttpGet]
        [Route("{Id:int}")]
        public async Task<ActionResult<Passageiro>> GetById(
            [FromServices] DataContext context, int id)
        {
            try
            {
                var passageiros = await context.Passageiros.FirstOrDefaultAsync(x => x.Id == id);
                if (passageiros == null)
                {
                    return NotFound();
                }
                return Ok(passageiros);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Passageiro>> Post(
            [FromServices] DataContext context,[FromBody] Passageiro passageiro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Passageiros.Add(passageiro);
                    await context.SaveChangesAsync();
                    return CreatedAtAction("Get", new { id = passageiro.Id }, passageiro);
                    //return Ok(passageiro);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Put(int id, Passageiro passageiro)
        {
            if (id != passageiro.Id)
            {
                return BadRequest();
            }

            _context.Entry(passageiro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(passageiro);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassageiroExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Passageiro>> Delete(int id)
        {
            var passageiros = await _context.Passageiros.FindAsync(id);
            if (passageiros == null)
            {
                return NotFound();
            }
            _context.Passageiros.Remove(passageiros);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Deletado com sucesso!"});
        }

        private bool PassageiroExists(int id)
        {
            return _context.Passageiros.Any(e => e.Id == id);
        }
    }
}