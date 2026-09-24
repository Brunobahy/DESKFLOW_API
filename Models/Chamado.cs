using System.ComponentModel.DataAnnotations;

namespace DeskFlow.Models
{
    public class Chamado
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string? Prioridade { get; set; }
        public string? Status { get; set; } = "Aberto";
        public string SolicitanteNome { get; set; }
        public DateTime? DataAbertura { get; set; } = DateTime.Now;
        public DateTime? DataFechamento { get; set; }
        public string? Solucao { get; set; }

        public string CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
        public List<Interacao> Interacoes { get; set; } = new();

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
            Interacao interacao = new Interacao(
                    "Sistema",
                    $"Chamado teve os status alterado para {statusAlterado}"
                );

            interacao.ChamadoId = Id;
            Interacoes.Add(interacao);

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
            Interacoes.Add(interacao);

        }
    }
}