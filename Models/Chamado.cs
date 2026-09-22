using System.ComponentModel.DataAnnotations;

namespace DeskFlow.Models
{
    public class Chamado
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Prioridade { get; set; }
        public string Status { get; set; } = "Aberto";
        public string SolicitanteNome { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataFechamento { get; set; }
        public string Solucao { get; set; }
        public int CategoriaId { get; set; }

        public void Atualizar(Chamado chamadoAtualizado)
        {
            Titulo = chamadoAtualizado.Titulo;
            Descricao = chamadoAtualizado.Descricao;
            Prioridade = chamadoAtualizado.Prioridade;
            Status = chamadoAtualizado.Status;
            Solucao = chamadoAtualizado.Solucao;
            CategoriaId = chamadoAtualizado.CategoriaId;
        }



    }
}