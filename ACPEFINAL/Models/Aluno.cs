namespace ACPEFINAL.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public DateTime DataCriacao { get; set; }

        public Aluno()
        {
            this.Id = 0;
            this.Nome = "";
            this.Cpf = "";
            this.Email = "";
            this.Senha = "";
            this.DataNascimento = DateTime.Now; 
            this.Sexo = "";
            this.Telefone = "";
            this.DataCriacao = DateTime.Now;
        }
    }
}
