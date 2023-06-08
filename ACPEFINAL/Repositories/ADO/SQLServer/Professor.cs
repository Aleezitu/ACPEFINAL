using ACPEFINAL.Models;
using Microsoft.Data.SqlClient;

namespace ACPEFINAL.Repositories.ADO.SQLServer
{
    public class Professor
    {
        private readonly string connectionString;
        public Professor(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Models.Professor perfilProfessor(int id)
        {
            Models.Professor professor = new Models.Professor();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT nome, data_nascimento, cpf, sexo, telefone, log.email AS email FROM Professores as pro INNER JOIN Login as log ON (pro.id_login=log.id_login) WHERE id_professor = @id;";

                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;

                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.Read())
                    {
                        professor.Nome = dr["nome"].ToString();
                        professor.DataNascimento = (DateTime)dr["data_nascimento"];
                        professor.Cpf = dr["cpf"].ToString();
                        professor.Sexo = dr["sexo"].ToString();
                        professor.Telefone = dr["telefone"].ToString();
                        professor.Email = dr["email"].ToString();
                    }
                }
            }

            return professor;
        }

        public Models.RecadosAlunos pegarIdAlunosRecados(int idProfessor)
        {
            RecadosAlunos recadosAlunos = new RecadosAlunos();

            List<Models.Aluno> alunos = new List<Models.Aluno>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = "SELECT alu.id_aluno AS id_aluno, alu.nome AS nome FROM Alunos AS alu LEFT JOIN TurmasAlunos AS tua ON (alu.id_aluno=tua.id_aluno) LEFT JOIN Turmas AS tur ON (tua.id_turma=tur.id_turma) LEFT JOIN TurmasProfessores AS tup ON (tur.id_turma=tup.id_turma) LEFT JOIN Professores AS pro ON (tup.id_professor=pro.id_professor) WHERE pro.id_professor = @idProfessor";

                    command.Parameters.Add(new SqlParameter("@idProfessor", System.Data.SqlDbType.Int)).Value = idProfessor;

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Models.Aluno aluno = new Models.Aluno();
                        aluno.Id = (int)dr["id_aluno"];
                        aluno.Nome = dr["nome"].ToString();

                        alunos.Add(aluno);
                    }
                }
                recadosAlunos.Alunos = alunos;
            }

            return recadosAlunos;
        }

        public void cadastrarRecado(Models.RecadosAlunos recadosAlunos, int idProfessor)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO Recados (id_professor, id_aluno, assunto, descricao, data) values (@id_professor, @id_aluno, @assunto, @descricao, @data); select convert(int,@@identity) as id;;";

                    command.Parameters.Add(new SqlParameter("@id_professor", System.Data.SqlDbType.Int)).Value = idProfessor;
                    command.Parameters.Add(new SqlParameter("@id_aluno", System.Data.SqlDbType.Int)).Value = recadosAlunos.Recado.Id;
                    command.Parameters.Add(new SqlParameter("@assunto", System.Data.SqlDbType.VarChar)).Value = recadosAlunos.Recado.Assunto;
                    command.Parameters.Add(new SqlParameter("@descricao", System.Data.SqlDbType.VarChar)).Value = recadosAlunos.Recado.Descricao;
                    command.Parameters.Add(new SqlParameter("@data", System.Data.SqlDbType.Date)).Value = recadosAlunos.Recado.Data;

                    command.ExecuteScalar();
                }
            }
        }

        public Models.TarefasAlunos pegarIdAlunosTarefas(int idProfessor)
        {
            TarefasAlunos tarefaAlunos = new TarefasAlunos();

            List<Models.Aluno> alunos = new List<Models.Aluno>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = "SELECT alu.id_aluno AS id_aluno, alu.nome AS nome FROM Alunos AS alu LEFT JOIN TurmasAlunos AS tua ON (alu.id_aluno=tua.id_aluno) LEFT JOIN Turmas AS tur ON (tua.id_turma=tur.id_turma) LEFT JOIN TurmasProfessores AS tup ON (tur.id_turma=tup.id_turma) LEFT JOIN Professores AS pro ON (tup.id_professor=pro.id_professor) WHERE pro.id_professor = @idProfessor";

                    command.Parameters.Add(new SqlParameter("@idProfessor", System.Data.SqlDbType.Int)).Value = idProfessor;
                    
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        Models.Aluno aluno = new Models.Aluno();
                        aluno.Id = (int)dr["id_aluno"];
                        aluno.Nome = dr["nome"].ToString();

                        alunos.Add(aluno);
                    }
                }
                tarefaAlunos.Alunos = alunos;
            }
            return tarefaAlunos;
        }

        public void cadastrarTarefas(Models.TarefasAlunos tarefasAlunos, int idProfessor)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO Tarefas (id_professor, id_aluno, assunto, data, local_arquivo) values (@id_professor, @id_aluno, @assunto, @data, @local_arquivo); select convert(int,@@identity) as id;;";

                    command.Parameters.Add(new SqlParameter("@id_professor", System.Data.SqlDbType.Int)).Value = idProfessor;
                    command.Parameters.Add(new SqlParameter("@id_aluno", System.Data.SqlDbType.Int)).Value = tarefasAlunos.Tarefa.Id;
                    command.Parameters.Add(new SqlParameter("@assunto", System.Data.SqlDbType.VarChar)).Value = tarefasAlunos.Tarefa.Assunto;
                    command.Parameters.Add(new SqlParameter("@data", System.Data.SqlDbType.Date)).Value = tarefasAlunos.Tarefa.Data;
                    command.Parameters.Add(new SqlParameter("@local_arquivo", System.Data.SqlDbType.VarChar)).Value = tarefasAlunos.Tarefa.LocalArquivo;

                    command.ExecuteScalar();
                }
            }
        }
    }
}
