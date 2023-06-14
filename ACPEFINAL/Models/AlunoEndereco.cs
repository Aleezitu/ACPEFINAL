namespace ACPEFINAL.Models
{
    public class AlunoEndereco
    {
        public Aluno Aluno { get; set; }
        public Endereco Endereco { get; set; }
        
        public AlunoEndereco()
        {
            Endereco = new Endereco();
            Aluno = new Aluno();
        }
    }
}
