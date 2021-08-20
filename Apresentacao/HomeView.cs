using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace projeto_gama_jobsnet.Apresentacao
{
  public class HomeView
  {
      public string Mensagem
      {
          get
          {
              return "JobsNet conectando oportunidades";
          }
      }

      public List<string> Endpoints
      {
          get
          {
              return new List<string>()
              {
                  "/vagas",
                  "/candidatos",
                  "/swagger"
              };
          }
      }
  }
}