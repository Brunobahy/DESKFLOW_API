namespace DeskFlow.Models
{
    // Id, ChamadoId, Autor, Mensagem e DataRegistro,
    public class Interacao
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? ChamadoId { get; set; }
        public string Autor { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataRegistro { get; set; } = DateTime.Now;

        public Interacao(string autor, string mensagem)
        {
            Autor = autor;
            Mensagem = mensagem;
        }
    }
}