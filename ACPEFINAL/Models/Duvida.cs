namespace ACPEFINAL.Models
{
    public class Duvida
    {
        public int IdFaq { get; set; }
        public int IdPergunta { get; set; }
        public int IdResposta { get; set; }
        public string Pergunta { get; set; }
        public string Resposta { get; set; }
        public string Email { get; set; }
        public DateTime DataPergunta { get; set; }

        public Duvida()
        {
            this.IdFaq = 0;
            this.IdPergunta = 0;
            this.IdResposta = 0;
            this.Pergunta = "";
            this.Resposta = "";
            this.Email = "";
            this.DataPergunta = DateTime.Now;
        }
    }
}
