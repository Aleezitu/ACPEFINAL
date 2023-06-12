namespace ACPEFINAL.Models
{
    public class AlunoEnderecoLogin
    {
        public List<Aluno> Aluno { get; set; }
        public List<Endereco> Endereco { get; set; }

        public AlunoEnderecoLogin()
        {
            Endereco = new List<Endereco>();
            Aluno = new List<Aluno>();
        }
    }
}
