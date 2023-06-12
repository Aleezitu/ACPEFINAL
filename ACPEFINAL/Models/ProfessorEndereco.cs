namespace ACPEFINAL.Models
{
    public class ProfessorEndereco
    {
        public List<Professor> Professor { get; set; }
        public List<Endereco> Endereco { get; set; }

        public ProfessorEndereco()
        {
            Endereco = new List<Endereco>();
            Professor = new List<Professor>();
        }
    }
}
