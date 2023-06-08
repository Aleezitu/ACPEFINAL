namespace ACPEFINAL.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCriacao { get; set; }
        public string TipoUsuario { get; set; }





        public Admin()
        {
            this.Id = 0;
            this.Nome = "";
            this.Cpf = "";
            this.Email = "";
            this.Senha = "";
            this.Telefone = "";
            this.DataCriacao = DateTime.Now;
            this.TipoUsuario = "Administrador";
        }
    }
}
