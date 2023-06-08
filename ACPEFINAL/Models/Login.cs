namespace ACPEFINAL.Models
{
    public class Login
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int TipoUsuario { get; set; }

        public Login()
        {
            this.Id = 0;
            this.Email = "";
            this.Senha = "";
            this.TipoUsuario = 0;
        }
    }
}
