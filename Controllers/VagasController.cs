using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projeto_gama_jobsnet.Models;
using projeto_gama_jobsnet.Servicos;

namespace projeto_gama_jobsnet.Controllers
{
    [ApiController]
    public class VagasController : ControllerBase
    {
        private readonly DbContexto _context;

        public VagasController(DbContexto context)
        {
            _context = context;
        }

        // GET: Vagas
        [HttpGet]
        [Route("/vagas")]
        public async Task<IActionResult> Index()
        {
            return StatusCode(200, await _context.Vagas.ToListAsync());
        }

        // POST: Vagas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("/vagas")]
        public async Task<IActionResult> Create([Bind("VagaId,nomeVaga,DescricaoVaga")] Vaga vaga)
        {
            if(_context.Vagas.Any(x => x.NomeVaga.Equals(vaga.NomeVaga)))
            {
                return StatusCode(401, new {
                    Mensagem = $"Já existe uma profissão criada com o nome {vaga.NomeVaga}"
                });
            }
            
            _context.Add(vaga);
            await _context.SaveChangesAsync();
            return StatusCode(201,vaga);
            
        }

        
        [HttpPut]
        [Route("/vagas/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("VagaId,nomeVaga,DescricaoVaga")] Vaga vaga)
        {
            if (id != vaga.VagaId)
            {
                return NotFound();
            }

            if(_context.Vagas.Any(x => x.NomeVaga.Equals(vaga.NomeVaga)&&x.VagaId!=vaga.VagaId))
            {
                return StatusCode(401, new {
                    Mensagem = $"Já existe uma profissão criada com o nome {vaga.NomeVaga}"
                });
            }

            try
            {
                _context.Update(vaga);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VagaExists(vaga.VagaId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
                return StatusCode(200,vaga);
        }

        // POST: Vagas/Delete/5
        [HttpDelete]
        [Route("/vagas/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vaga = await _context.Vagas.FindAsync(id);
            _context.Vagas.Remove(vaga);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }

        [HttpGet]
        [Route("/vagas/{id}")]
        public async Task<Vaga> Get(int id)
        {
            var vaga = await _context.Vagas.FindAsync(id);
            return vaga;
        }

        private bool VagaExists(int id)
        {
            return _context.Vagas.Any(e => e.VagaId == id);
        }
    }
}
