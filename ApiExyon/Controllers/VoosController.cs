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
    public class VoosController : ControllerBase
    {
        private readonly DataContext _context;

        public VoosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Voo>>> Get([FromServices] DataContext context)
        {
            var voos = await context.Voos.Include(c => c.CiaAerea).Include(p => p.Passageiro)
                .AsNoTracking().ToListAsync();
            return voos;
        }

        [HttpGet]
        [Route("{Id:int}")]
        public async Task<ActionResult<Voo>> GetById([FromServices] DataContext context, int id)
        {
            try
            {
                var voos = await context.Voos.Include(c => c.CiaAerea).Include(p => p.Passageiro)
                    .AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                if (voos == null)
                {
                    return NotFound();
                }
                return voos;
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("cia/{ciaAereaId:int}")]
        public async Task<ActionResult<List<Voo>>> GetByCiaAereaId([FromServices] DataContext context, int ciaAereaId)
        {
            try
            {
                var voos = await context.Voos.Include(c => c.CiaAerea).Include(p => p.Passageiro)
                    .AsNoTracking().Where(c => c.CiaAereaId == ciaAereaId).ToListAsync();
                if (voos == null)
                {
                    return NotFound();
                }
                return voos;
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("pass/{passageiroId:int}")]
        public async Task<ActionResult<List<Voo>>> GetByPassageiroId([FromServices] DataContext context, int passageiroId)
        {
            try
            {
                var voos = await context.Voos.Include(c => c.CiaAerea).Include(p => p.Passageiro)
                    .AsNoTracking().Where(p => p.PassageiroId == passageiroId).ToListAsync();
                if (voos == null)
                {
                    return NotFound();
                }
                return voos;
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

      /*  [HttpGet]
        [Route("voo/{ciaAereaNumdoVoo:int}")]
        public async Task<ActionResult<List<Voo>>> GetByCiaAereaNumdoVoo([FromServices] DataContext context, string ciaAereaNumdoVoo)
        {
            try
            {
                var voos = await context.Voos.Include(c => c.CiaAerea).Include(p => p.Passageiro)
                    .AsNoTracking().Where(c => c.NumdoVoo = ciaAereaNumdoVoo).ToListAsync();
                if (voos == null)
                {
                    return NotFound();
                }
                return voos;
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        } */


        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Voo>> Post([FromServices] DataContext context,[FromBody] Voo voo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Voos.Add(voo);
                    await context.SaveChangesAsync();
                    return CreatedAtAction("Get", new { id = voo.Id }, voo);
                    //return Ok(voo);
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
        public async Task<IActionResult> Put(int id, Voo voo)
        {
            if (id != voo.Id)
            {
                return BadRequest();
            }

            _context.Entry(voo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(voo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VooExists(id))
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
        public async Task<ActionResult<Voo>> Delete(int id)
        {
            var voo  = await _context.Voos.FindAsync(id);
            if (voo == null)
            {
                return NotFound();
            }
            _context.Voos.Remove(voo);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Deletado com sucesso!"});
        }

        private bool VooExists(int id)
        {
            return _context.Voos.Any(e => e.Id == id);
        }
    }
}