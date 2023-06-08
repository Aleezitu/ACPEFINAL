using ACPEFINAL.Models;
using Microsoft.Data.SqlClient;

namespace ACPEFINAL.Repositories.ADO.SQLServer
{
    public class Aluno
    {
        private readonly string connectionString;
        public Aluno(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Models.Aluno perfilAluno(int id)
        {
            Models.Aluno aluno = new Models.Aluno();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT nome, data_nascimento, cpf, sexo, telefone, log.email AS email FROM Alunos as alu INNER JOIN Login as log ON (alu.id_login=log.id_login) WHERE id_aluno = @id;";

                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;

                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.Read())
                    {
                        aluno.Nome = dr["nome"].ToString();
                        aluno.DataNascimento = (DateTime)dr["data_nascimento"];
                        aluno.Cpf = dr["cpf"].ToString();
                        aluno.Sexo = dr["sexo"].ToString();
                        aluno.Telefone = dr["telefone"].ToString();
                        aluno.Email = dr["email"].ToString();
                    }
                }
            }

            return aluno;
        }

        public List<Models.Recado> mostrarRecados(int id)
        {
            List<Models.Recado> recados = new List<Models.Recado>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = "SELECT rec.assunto AS assunto, rec.descricao AS descricao, rec.data AS data, pro.nome AS nome_professor FROM Recados AS rec INNER JOIN Professores as pro ON (rec.id_professor=pro.id_professor) WHERE id_aluno = @id";
                    
                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Models.Recado recado = new Models.Recado();
                        recado.Assunto = dr["assunto"].ToString();
                        recado.Descricao = dr["descricao"].ToString();
                        recado.Data = (DateTime)dr["data"];
                        recado.NomeProfessor = dr["nome_professor"].ToString();


                        recados.Add(recado);
                    }
                }
            }

            return recados;
        }

        public List<Models.Tarefa> mostrarTarefas(int id)
        {
            List<Models.Tarefa> tarefas = new List<Models.Tarefa>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = "SELECT tar.assunto AS assunto, tar.data AS data, tar.local_arquivo AS local_arquivo, pro.nome AS nome_professor FROM Tarefas AS tar INNER JOIN Professores as pro ON (tar.id_professor=pro.id_professor) WHERE id_aluno = @id";

                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Models.Tarefa tarefa = new Models.Tarefa();
                        tarefa.Assunto = dr["assunto"].ToString();
                        tarefa.LocalArquivo = dr["local_arquivo"].ToString();
                        tarefa.Data = (DateTime)dr["data"];
                        tarefa.NomeProfessor = dr["nome_professor"].ToString();


                        tarefas.Add(tarefa);
                    }
                }
            }
            return tarefas;
        }
    }
}
