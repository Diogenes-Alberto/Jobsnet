using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System;

namespace projeto_gama_jobsnet.Models
{
  [Table("candidaturas")]
  public class Candidatura
  {

    [Key]
    [Column("candidatura_id", TypeName = "int")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CandidaturaId{get; set;}

    [ForeignKey("candidato_id")]
    [Column("candidato_id", TypeName = "int")]
    [Required(ErrorMessage="Campo Candidato id é obrigatório")]
    public int CandidatoId { get;set; }

    
    [Column("vaga_id", TypeName = "int")]
    [ForeignKey("vaga_id")]
    [Required(ErrorMessage="Campo Vaga id é obrigatório")]
    public int VagaId{get; set;}
  }
}