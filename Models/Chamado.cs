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
        public DateTime DataAbertura { get; set; } = DateTime.Now;
        public DateTime DataFechamento { get; set; }
        public string Solucao { get; set; } = null;
        public int CategoriaId { get; set; }
        public List<Interacao> Comentarios { get; set; } = new();

        public Chamado()
        {
            Comentarios = new List<Interacao>
            {
                new Interacao(
                    Id,
                    "Sistema",
                    $"Chamado aberto dia {DateTime.Now.Day}/{DateTime.Now.Month}"
                )
            };
        }

        public void Atualizar(Chamado chamadoAtualizado)
        {
            Titulo = chamadoAtualizado.Titulo;
            Descricao = chamadoAtualizado.Descricao;
            Prioridade = chamadoAtualizado.Prioridade;
            Status = chamadoAtualizado.Status;
            Solucao = chamadoAtualizado.Solucao;
            CategoriaId = chamadoAtualizado.CategoriaId;
        }

        public void AlterarStatus(string statusAlterado)
        {
            Status = statusAlterado;
        }

        public void Finalizar()
        {

            if (Solucao == null)
            {
                throw new ValidationException("Campo 'solução' não preenchido");
            }
            else
            {
                AlterarStatus("Fechado");
                DataFechamento = DateTime.Now;
            }
        }

        public void AdicionarInteracao(Interacao interacao)
        {
            if (Status == "Fechado")
            {
                throw new ValidationException("Você não pode comentar em chamados Fechados!");
            }
            Comentarios.Add(interacao);

        }
    }
}