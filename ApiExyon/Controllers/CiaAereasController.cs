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
    public class CiaAereasController : ControllerBase
    {
        private readonly DataContext _context;

        public CiaAereasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<CiaAerea>>> Get([FromServices] DataContext context)
        {
            var ciaAereas = await context.CiaAereas.AsNoTracking().ToListAsync();
            return ciaAereas;
        }

        [HttpGet]
        [Route("{Id:int}")]
        public async Task<ActionResult<CiaAerea>> GetById([FromServices] DataContext context, int id)
        {
            try
            {
                var ciaAereas = await context.CiaAereas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                return ciaAereas;
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<CiaAerea>> Post([FromServices] DataContext context,[FromBody] CiaAerea ciaAerea)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.CiaAereas.Add(ciaAerea);
                    await context.SaveChangesAsync();
                    return CreatedAtAction("Get", new { id = ciaAerea.Id }, ciaAerea);
                    //return Ok(ciaAerea);
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
        public async Task<IActionResult> Put(int id, CiaAerea ciaAerea)
        {
            if (id != ciaAerea.Id)
            {
                return BadRequest();
            }

            _context.Entry(ciaAerea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(ciaAerea);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CiaAereaExists(id))
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
        public async Task<ActionResult<CiaAerea>> Delete(int id)
        {
            var ciaAereas = await _context.CiaAereas.FindAsync(id);
            if (ciaAereas== null)
            {
                return NotFound();
            }

            _context.CiaAereas.Remove(ciaAereas);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Deletado com sucesso!"});
        }

        private bool CiaAereaExists(int id)
        {
            return _context.CiaAereas.Any(e => e.Id == id);
        }
    }
}