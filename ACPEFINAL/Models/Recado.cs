namespace ACPEFINAL.Models
{
    public class Recado
    {
        public int Id { get; set; }
        public string NomeAluno { get; set; }
        public string Assunto{ get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public string NomeProfessor { get; set; }
        public int StatusRecado { get; set; }

        public Recado() 
        { 
            this.Id= 0;
            this.NomeAluno = "";
            this.Assunto = "";
            this.Data = DateTime.Now;
            this.Descricao = "";
            this.NomeProfessor = "";
            this.StatusRecado = 0;
        }
    }
}
