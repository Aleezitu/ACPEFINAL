namespace ACPEFINAL.Models
{
    public class ProfessorAluno
    {
        public Professor Professor { get; set; }
        public Aluno Aluno { get; set; }
        public Admin Admin { get; set; }

        public int IdEndereco { get; set; }
        public int IdUf { get; set; }
        public int IdLogin { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set;}

        public ProfessorAluno()
        {
            Professor = new Professor();
            Aluno = new Aluno();
            Admin = new Admin();
            IdEndereco = 0;
            IdUf = 0;
            IdLogin = 0;
            Rua = "";
            Numero = "";
            Complemento = "";
            Cidade = "";
            Cep = "";
        }
    }
}
