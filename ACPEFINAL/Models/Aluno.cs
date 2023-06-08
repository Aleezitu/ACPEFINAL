namespace ACPEFINAL.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string NomeResponsavel { get; set; }
        public string CpfResponsavel { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCriacao { get; set; }
        public string TipoUsuario { get; set; }

        public Aluno()
        {
            this.Id = 0;
            this.Nome = "";
            this.Cpf = "";
            this.Email = "";
            this.Senha = "";
            this.DataNascimento = DateOnly.MaxValue; 
            this.Sexo = "";
            this.NomeResponsavel = "";
            this.CpfResponsavel = "";
            this.Telefone = "";
            this.DataCriacao = DateTime.Now;
            this.TipoUsuario = "Administrador";
        }
    }
}
