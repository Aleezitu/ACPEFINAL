namespace ACPEFINAL.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Sigla { get; set; }

        public Endereco()
        {
            this.Id = 0;
            this.Rua = "";
            this.Numero = "";
            this.Complemento = "";
            this.Cidade = "";
            this.Cep = "";
            this.Estado = "";
            this.Pais = "";
            this.Sigla = "";
        }
    }
}
