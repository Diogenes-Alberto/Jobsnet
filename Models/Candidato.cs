using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System;

namespace projeto_gama_jobsnet.Models
{
  [Table("candidatos")]
  public class Candidato
  {
    [Key]
    [Column("candidato_id")]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CandidatoId { get;set; }

    
    [Column("nome", TypeName = "varchar")]
    [MaxLength(50)]
    [Required(ErrorMessage="O nome do candidato é obrigatório")]
    public string NomeCandidato{get; set;}

   
    [Column("estado_civil", TypeName = "varchar")]
    [MaxLength(10)]
    [Required(ErrorMessage="O estado civil é obrigatório")]
    public string EstadoCivil{get; set;}

    
    [Column("genero", TypeName = "varchar")]
    [MaxLength(10)]
    [Required(ErrorMessage="O genero é obrigatório")]
    public string Genero{get; set;}


   
    [Column("data_nascimento", TypeName = "date")]
    [Required(ErrorMessage="A Data de nascimento é obrigatório")]
    public DateTime  DataNascimento{get; set;}


   
    [Column("cep", TypeName = "varchar")]
    [MaxLength(14)]
    [Required(ErrorMessage="Campo cep é obrigatório")]
    public string Cep { get;set; }

   
    [Column("endereco", TypeName = "varchar")]
    [MaxLength(50)]
    [Required(ErrorMessage="Campo endereco é obrigatório")]
    public string Endereco { get;set; }
    
   
    [Column("numero", TypeName = "varchar")]
    [MaxLength(10)]
    [Required(ErrorMessage="Campo numero é obrigatório")]
    public string Numero { get;set; }

   
    [Column("complemento", TypeName = "varchar")]
    [MaxLength(50)]
    [Required(ErrorMessage="Campo complemento é obrigatório")]
    public string Complemento { get;set; }

    
    [Column("bairro", TypeName = "varchar")]
    [MaxLength(25)]
    [Required(ErrorMessage="Campo bairro é obrigatório")]
    public string Bairro { get;set; }

    
    [Column("cidade", TypeName = "varchar")]
    [MaxLength(30)]
    [Required(ErrorMessage="Campo Cidade é obrigatório")]
    public string Cidade { get;set; }

    
    [Column("uf", TypeName = "varchar")]
    [MaxLength(2)]
    [Required(ErrorMessage="Campo UF é obrigatório")]
    public string UF { get;set; }


    
    [Column("telefone_fixo", TypeName = "varchar")]
    [MaxLength(14)]
    public string TelefoneFixo { get;set; }

    [Column("telefone_movel", TypeName = "varchar")]
    [MaxLength(14)]
    public string TelefoneMovel { get;set; }


    [Column("email", TypeName ="varchar")]
    [MaxLength(50)]
    public string EmailCandidato{get; set;}


    [Column("cpf", TypeName = "varchar")]
    [MaxLength(20)]
    public string Cpf{get; set;}
    
    [Column("rg", TypeName = "varchar")]
    [MaxLength(20)]
    public string RG{get; set;}

    [Column("possui_veiculo",TypeName="bit" )]
    public Boolean PossuiVeiculo{get; set;}

    [Column("habilitacao", TypeName = "varchar")]
    [MaxLength(20)]
    public String TipoHabilitacao{get; set;}

    [Column("vaga_id", TypeName = "int")]
    [ForeignKey("VagaId")]
    [Required(ErrorMessage="Campo Vaga id é obrigatório")]
    public int VagaId{get; set;}

    [JsonIgnore]
    public Vaga Cargo { get;set; }


    public bool CpfValido()
    {
      var cpf = this.Cpf;
      int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
      int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
      string tempCpf;
      string digito;
      int soma;
      int resto;
      char[] arrayCpf=cpf.ToCharArray();

      cpf = cpf.Trim();
      cpf = cpf.Replace(".", "").Replace("-", "");
      if (cpf.Length != 11)
      {
        return false;
      }
      if((cpf[0]==cpf[1])&&(cpf[1]==cpf[2])&&(cpf[2]==cpf[3])&&(cpf[3]==cpf[4])&&(cpf[4]==cpf[5])&&
         (cpf[5]==cpf[6])&&(cpf[6]==cpf[7])&&(cpf[7]==cpf[8])&&(cpf[8]==cpf[9])&&(cpf[9]==cpf[10]) )
      {
        return false;
      }
          
      tempCpf = cpf.Substring(0, 9);
      soma =0;
      for (int i = 0; i < 9; i++)
          soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
      resto = soma % 11;
      if (resto < 2)
          resto = 0;
      else
          resto = 11 - resto;
      digito = resto.ToString();
      tempCpf = tempCpf + digito;
      soma = 0;
      for (int i = 0; i < 10; i++)
          soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
      resto = soma % 11;
      if (resto < 2)
          resto = 0;
      else
          resto = 11 - resto;
      digito = digito + resto.ToString();
      return cpf.EndsWith(digito);
    }

  }
}