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
    public class CandidaturasController : ControllerBase
    {
        private readonly DbContexto _context;

        public CandidaturasController(DbContexto context)
        {
            _context = context;
        }

        // GET: Candidaturas
        [HttpGet]
        [Route("/candidaturas")]
        public async Task<IActionResult> Index()
        {
            return StatusCode(200, await _context.Candidaturas.ToListAsync());
        }

        // POST: Candidaturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("/candidaturas")]
        public async Task<IActionResult> Create([Bind("CandidaturaId,CandidatoId,VagaId")] Candidatura candidatura)
        {
            //verifica se já existe algum valor no BD igual ao que quero registrar
            _context.Add(candidatura);
            await _context.SaveChangesAsync();
            return StatusCode(201,candidatura);
            
        }

        
        [HttpPut]
        [Route("/candidaturas/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("CandidaturaId,CandidatoId,VagaId")] Candidatura candidatura)
        {
            if (id != candidatura.CandidaturaId)
            {
                return NotFound();
            }
            //verifica se já existe algum valor no BD igual ao que quero alterar
            //mas tambem verifica se nao e o mesmo objeto
            try
            {
                _context.Update(candidatura);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidaturaExists(candidatura.CandidaturaId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
                return StatusCode(200,candidatura);
        }

        // POST: Candidaturas/Delete/5
        [HttpDelete]
        [Route("/candidaturas/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var candidatura = await _context.Candidaturas.FindAsync(id);
            _context.Candidaturas.Remove(candidatura);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }

        [HttpGet]
        [Route("/candidaturas/{id}")]
        public async Task<Candidatura> Get(int id)
        {
            var candidatura = await _context.Candidaturas.FindAsync(id);
            return candidatura;
        }

        private bool CandidaturaExists(int id)
        {
            return _context.Candidaturas.Any(e => e.CandidaturaId == id);
        }
    }
}
