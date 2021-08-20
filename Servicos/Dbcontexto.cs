using projeto_gama_jobsnet.Models;
using Microsoft.EntityFrameworkCore;

namespace projeto_gama_jobsnet.Servicos
{
  public class DbContexto : DbContext
  {

    public DbContexto(DbContextOptions<DbContexto> options) : base(options) { }

    public DbSet<Vaga> Vagas { get; set; }
    public DbSet<Candidato> Candidatos{get; set;}
    public DbSet<Candidatura> Candidaturas{get; set;}

  }
}