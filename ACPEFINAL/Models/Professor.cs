﻿namespace ACPEFINAL.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
        public string Formacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public string TipoUsuario { get; set; }

        public Professor()
        {
            this.Id = 0;
            this.Nome = "";
            this.Cpf = "";
            this.Email = "";
            this.Senha = "";
            this.DataNascimento = DateOnly.MaxValue;
            this.Sexo = "";
            this.Telefone = "";
            this.Formacao = "";
            this.DataCriacao = DateTime.Now;
            this.TipoUsuario = "Administrador";
        }
    }
}
