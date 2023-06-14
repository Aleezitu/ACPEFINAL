namespace ACPEFINAL.Models
{
    public class ProfessorEnderecos
    {
        public Professor Professor { get; set; }
        public Endereco Endereco { get; set; }

        public ProfessorEnderecos()
        {
            Endereco = new Endereco();
            Professor = new Professor();
        }
    }
}
