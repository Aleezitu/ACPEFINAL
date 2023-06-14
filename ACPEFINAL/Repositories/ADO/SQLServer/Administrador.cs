using ACPEFINAL.Models;
using Microsoft.Data.SqlClient;
using NuGet.Protocol.Plugins;
using System.Collections.Generic;
using System.Data;

namespace ACPEFINAL.Repositories.ADO.SQLServer
{
    public class Administrador
    {
        private readonly string connectionString;
        public Administrador(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void cadastrarAluno(Models.ProfessorAluno proAl)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO Login (email, senha) VALUES (@email, @senha); select convert(int,@@identity) as id;;";
                    command.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.VarChar)).Value = proAl.Aluno.Email;
                    command.Parameters.Add(new SqlParameter("@senha", System.Data.SqlDbType.VarChar)).Value = Configurations.Hash.CriarHash(proAl.Aluno.Senha);
                    proAl.IdLogin = (int)command.ExecuteScalar();


                    command.CommandText = "INSERT INTO Enderecos (id_uf, rua, numero, complemento, cidade, cep) VALUES (1, @rua, @numero, @complemento, @cidade, @cep); select convert(int,@@identity) as id;;";
                    command.Parameters.Add(new SqlParameter("@rua", System.Data.SqlDbType.VarChar)).Value = proAl.Rua;
                    command.Parameters.Add(new SqlParameter("@numero", System.Data.SqlDbType.VarChar)).Value = proAl.Numero;
                    command.Parameters.Add(new SqlParameter("@complemento", System.Data.SqlDbType.VarChar)).Value = proAl.Complemento;
                    command.Parameters.Add(new SqlParameter("@cidade", System.Data.SqlDbType.VarChar)).Value = proAl.Cidade;
                    command.Parameters.Add(new SqlParameter("@cep", System.Data.SqlDbType.VarChar)).Value = proAl.Cep;
                    proAl.IdEndereco = (int)command.ExecuteScalar();


                    command.CommandText = "INSERT INTO Alunos(id_endereco, id_login, id_tipo_usuario, nome, cpf, data_nascimento, sexo, telefone) VALUES(@id_endereco, @id_login, 3, @nome, @cpf, @data_nascimento, @sexo, @telefone); select convert(int,@@identity) as id;;";

                    command.Parameters.Add(new SqlParameter("@id_endereco", System.Data.SqlDbType.Int)).Value = proAl.IdEndereco;
                    command.Parameters.Add(new SqlParameter("@id_login", System.Data.SqlDbType.Int)).Value = proAl.IdLogin;
                    command.Parameters.Add(new SqlParameter("@nome", System.Data.SqlDbType.VarChar)).Value = proAl.Aluno.Nome;
                    command.Parameters.Add(new SqlParameter("@cpf", System.Data.SqlDbType.VarChar)).Value = proAl.Aluno.Cpf;
                    command.Parameters.Add(new SqlParameter("@data_nascimento", System.Data.SqlDbType.Date)).Value = proAl.Aluno.DataNascimento;
                    command.Parameters.Add(new SqlParameter("@sexo", System.Data.SqlDbType.VarChar)).Value = proAl.Aluno.Sexo;
                    command.Parameters.Add(new SqlParameter("@telefone", System.Data.SqlDbType.VarChar)).Value = proAl.Aluno.Telefone;

                    proAl.Aluno.Id = (int)command.ExecuteScalar();

                    command.CommandText = "INSERT INTO TurmasAlunos (id_turma, id_aluno) VALUES (1, @id_aluno); select convert(int,@@identity) as id;;";

                    command.Parameters.Add(new SqlParameter("@id_aluno", System.Data.SqlDbType.Int)).Value = proAl.Aluno.Id;

                    command.ExecuteScalar();
                }
            }
        }

        public void cadastrarProfessor(Models.ProfessorAluno proAl)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO Login (email, senha) VALUES (@email, @senha); select convert(int,@@identity) as id;;";
                    command.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.VarChar)).Value = proAl.Professor.Email;
                    command.Parameters.Add(new SqlParameter("@senha", System.Data.SqlDbType.VarChar)).Value = Configurations.Hash.CriarHash(proAl.Professor.Senha);
                    proAl.IdLogin = (int)command.ExecuteScalar();


                    command.CommandText = "INSERT INTO Enderecos (id_uf, rua, numero, complemento, cidade, cep) VALUES (1, @rua, @numero, @complemento, @cidade, @cep); select convert(int,@@identity) as id;;";
                    command.Parameters.Add(new SqlParameter("@rua", System.Data.SqlDbType.VarChar)).Value = proAl.Rua;
                    command.Parameters.Add(new SqlParameter("@numero", System.Data.SqlDbType.VarChar)).Value = proAl.Numero;
                    command.Parameters.Add(new SqlParameter("@complemento", System.Data.SqlDbType.VarChar)).Value = proAl.Complemento;
                    command.Parameters.Add(new SqlParameter("@cidade", System.Data.SqlDbType.VarChar)).Value = proAl.Cidade;
                    command.Parameters.Add(new SqlParameter("@cep", System.Data.SqlDbType.VarChar)).Value = proAl.Cep;
                    proAl.IdEndereco = (int)command.ExecuteScalar();


                    command.CommandText = "INSERT INTO Professores (id_endereco, id_login, id_tipo_usuario, nome, cpf, data_nascimento, sexo, telefone, formacao) VALUES (@id_endereco, @id_login, 2, @nome, @cpf, @data_nascimento, @sexo, @telefone, @formacao); select convert(int,@@identity) as id;;";

                    command.Parameters.Add(new SqlParameter("@id_endereco", System.Data.SqlDbType.Int)).Value = proAl.IdEndereco;
                    command.Parameters.Add(new SqlParameter("@id_login", System.Data.SqlDbType.Int)).Value = proAl.IdLogin;
                    command.Parameters.Add(new SqlParameter("@nome", System.Data.SqlDbType.VarChar)).Value = proAl.Professor.Nome;
                    command.Parameters.Add(new SqlParameter("@cpf", System.Data.SqlDbType.VarChar)).Value = proAl.Professor.Cpf;
                    command.Parameters.Add(new SqlParameter("@data_nascimento", System.Data.SqlDbType.Date)).Value = proAl.Professor.DataNascimento;
                    command.Parameters.Add(new SqlParameter("@sexo", System.Data.SqlDbType.VarChar)).Value = proAl.Professor.Sexo;
                    command.Parameters.Add(new SqlParameter("@telefone", System.Data.SqlDbType.VarChar)).Value = proAl.Professor.Telefone;
                    command.Parameters.Add(new SqlParameter("@formacao", System.Data.SqlDbType.VarChar)).Value = proAl.Professor.Formacao;

                    proAl.Professor.Id = (int)command.ExecuteScalar();
                }
            }
        }

        public void cadastrarAdmin(Models.ProfessorAluno proAl)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO Login (email, senha) VALUES (@email, @senha); select convert(int,@@identity) as id;;";
                    command.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.VarChar)).Value = proAl.Admin.Email;
                    command.Parameters.Add(new SqlParameter("@senha", System.Data.SqlDbType.VarChar)).Value = Configurations.Hash.CriarHash(proAl.Admin.Senha);
                    proAl.IdLogin = (int)command.ExecuteScalar();


                    command.CommandText = "INSERT INTO Admins(id_login, id_tipo_usuario, nome, cpf, telefone) VALUES(@id_login, 1, @nome, @cpf, @telefone); select convert(int,@@identity) as id;;";

                    command.Parameters.Add(new SqlParameter("@id_endereco", System.Data.SqlDbType.Int)).Value = proAl.IdEndereco;
                    command.Parameters.Add(new SqlParameter("@id_login", System.Data.SqlDbType.Int)).Value = proAl.IdLogin;
                    command.Parameters.Add(new SqlParameter("@nome", System.Data.SqlDbType.VarChar)).Value = proAl.Admin.Nome;
                    command.Parameters.Add(new SqlParameter("@cpf", System.Data.SqlDbType.VarChar)).Value = proAl.Admin.Cpf;
                    command.Parameters.Add(new SqlParameter("@telefone", System.Data.SqlDbType.VarChar)).Value = proAl.Admin.Telefone;

                    proAl.Admin.Id = (int)command.ExecuteScalar();
                }
            }
        }


        public Models.AlunoEnderecoLogin listarAlunos()
        {
            Models.AlunoEnderecoLogin alunoEnderecoLogins = new Models.AlunoEnderecoLogin();

            List<Models.Aluno> alunos = new List<Models.Aluno>();
            List<Models.Endereco> enderecos = new List<Models.Endereco>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = "SELECT log.id_login as id_login,ende.id_endereco as id_endereco, alu.id_aluno as id_aluno, ende.rua as rua, ende.numero as numero, ende.complemento as complemento, ende.cidade as cidade, ende.cep as cep, alu.nome as nome, alu.cpf as cpf, alu.data_nascimento as data_nascimento, alu.createdAt as data_criacao, alu.sexo as sexo, alu.telefone as telefone, log.email as email, ufs.nome as nomeestado, ufs.pais as pais, ufs.sigla as sigla FROM Alunos AS alu LEFT JOIN Login as log ON (log.id_login=alu.id_login) LEFT JOIN Enderecos AS ende ON (ende.id_endereco=alu.id_endereco) LEFT JOIN Ufs as ufs ON (ufs.id_uf=ende.id_uf) where ativo = 1";

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Models.Aluno aluno = new Models.Aluno();
                        aluno.Id = (int)dr["id_aluno"];
                        aluno.IdLogin = (int)dr["id_login"];
                        aluno.Nome = dr["nome"].ToString();
                        aluno.Cpf = dr["cpf"].ToString();
                        aluno.Email = dr["email"].ToString();
                        aluno.DataNascimento = (DateTime)dr["data_nascimento"];
                        aluno.Sexo = dr["sexo"].ToString();
                        aluno.Telefone = dr["telefone"].ToString();
                        aluno.DataCriacao = (DateTime)dr["data_criacao"];


                        alunos.Add(aluno);

                        Models.Endereco endereco = new Endereco();
                        endereco.Id = (int)dr["id_endereco"];
                        endereco.Rua = dr["rua"].ToString();
                        endereco.Numero = dr["numero"].ToString();
                        endereco.Complemento = dr["complemento"].ToString();
                        endereco.Cidade = dr["cidade"].ToString();
                        endereco.Estado = dr["nomeestado"].ToString();
                        endereco.Pais = dr["pais"].ToString();
                        endereco.Sigla = dr["sigla"].ToString();

                        enderecos.Add(endereco);
                    }
                }
                alunoEnderecoLogins.Aluno = alunos;
                alunoEnderecoLogins.Endereco = enderecos;
            }

            return alunoEnderecoLogins;
        }

        public Models.AlunoEndereco listarAluno(int id)
        {
            Models.AlunoEndereco alunoEndereco = new Models.AlunoEndereco();

            Models.Aluno alunos = new Models.Aluno();
            Models.Endereco enderecos = new Models.Endereco();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = "SELECT log.id_login as id_login,ende.id_endereco as id_endereco, alu.id_aluno as id_aluno, ende.rua as rua, ende.numero as numero, ende.complemento as complemento, ende.cidade as cidade, ende.cep as cep, alu.nome as nome, alu.cpf as cpf, alu.data_nascimento as data_nascimento, alu.createdAt as data_criacao, alu.sexo as sexo, alu.telefone as telefone, log.email as email, ufs.nome as nomeestado, ufs.pais as pais, ufs.sigla as sigla FROM Alunos AS alu LEFT JOIN Login as log ON (log.id_login=alu.id_login) LEFT JOIN Enderecos AS ende ON (ende.id_endereco=alu.id_endereco) LEFT JOIN Ufs as ufs ON (ufs.id_uf=ende.id_uf) WHERE alu.id_aluno = @id";

                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;

                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.Read())
                    {
                        Models.Aluno aluno = new Models.Aluno();
                        aluno.Id = (int)dr["id_aluno"];
                        aluno.IdLogin = (int)dr["id_login"];
                        aluno.Nome = dr["nome"].ToString();
                        aluno.Cpf = dr["cpf"].ToString();
                        aluno.Email = dr["email"].ToString();
                        aluno.DataNascimento = (DateTime)dr["data_nascimento"];
                        aluno.Sexo = dr["sexo"].ToString();
                        aluno.Telefone = dr["telefone"].ToString();
                        aluno.DataCriacao = (DateTime)dr["data_criacao"];

                        Models.Endereco endereco = new Endereco();
                        endereco.Id = (int)dr["id_endereco"];
                        endereco.Rua = dr["rua"].ToString();
                        endereco.Numero = dr["numero"].ToString();
                        endereco.Complemento = dr["complemento"].ToString();
                        endereco.Cidade = dr["cidade"].ToString();
                        endereco.Estado = dr["nomeestado"].ToString();
                        endereco.Pais = dr["pais"].ToString();
                        endereco.Sigla = dr["sigla"].ToString();

                        alunoEndereco.Aluno = aluno;
                        alunoEndereco.Endereco = endereco;
                    }
                }
            }

            return alunoEndereco;
        }

        public void atualizarAlunos(Models.AlunoEndereco alunoEndereco)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = "UPDATE Enderecos SET rua = @rua, numero = @numero, complemento = @complemento, cidade = @cidade, cep = @cep where id_endereco = @idENDERECO;";

                    command.Parameters.Add(new SqlParameter("@idENDERECO", System.Data.SqlDbType.Int)).Value = alunoEndereco.Endereco.Id;
                    command.Parameters.Add(new SqlParameter("@rua", System.Data.SqlDbType.VarChar)).Value = alunoEndereco.Endereco.Rua;
                    command.Parameters.Add(new SqlParameter("@numero", System.Data.SqlDbType.VarChar)).Value = alunoEndereco.Endereco.Numero;
                    command.Parameters.Add(new SqlParameter("@complemento", System.Data.SqlDbType.VarChar)).Value = alunoEndereco.Endereco.Complemento;
                    command.Parameters.Add(new SqlParameter("@cidade", System.Data.SqlDbType.VarChar)).Value = alunoEndereco.Endereco.Cidade;
                    command.Parameters.Add(new SqlParameter("@cep", System.Data.SqlDbType.VarChar)).Value = alunoEndereco.Endereco.Cep;
                    command.ExecuteScalar();


                    command.CommandText = "UPDATE Login SET email = @email where id_login = @idLOGIN;";
                    command.Parameters.Add(new SqlParameter("@idLOGIN", System.Data.SqlDbType.Int)).Value = alunoEndereco.Aluno.IdLogin;
                    command.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.VarChar)).Value = alunoEndereco.Aluno.Email;
                    command.ExecuteScalar();


                    command.CommandText = "UPDATE Alunos set nome = @nome, cpf = @cpf, data_nascimento = @data_nascimento, sexo = @sexo, telefone = @telefone WHERE id_aluno = @idALUNO";

                    command.Parameters.Add(new SqlParameter("@idALUNO", System.Data.SqlDbType.Int)).Value = alunoEndereco.Aluno.Id;
                    command.Parameters.Add(new SqlParameter("@nome", System.Data.SqlDbType.VarChar)).Value = alunoEndereco.Aluno.Nome;
                    command.Parameters.Add(new SqlParameter("@cpf", System.Data.SqlDbType.VarChar)).Value = alunoEndereco.Aluno.Cpf;
                    command.Parameters.Add(new SqlParameter("@data_nascimento", System.Data.SqlDbType.Date)).Value = alunoEndereco.Aluno.DataNascimento;
                    command.Parameters.Add(new SqlParameter("@sexo", System.Data.SqlDbType.VarChar)).Value = alunoEndereco.Aluno.Sexo;
                    command.Parameters.Add(new SqlParameter("@telefone", System.Data.SqlDbType.VarChar)).Value = alunoEndereco.Aluno.Telefone;

                    command.ExecuteScalar();
                }
            }
        }

        public Models.ProfessorEndereco listarProfessor()
        {
            Models.ProfessorEndereco alunoEnderecoLogins = new Models.ProfessorEndereco();

            List<Models.Professor> professores = new List<Models.Professor>();
            List<Models.Endereco> enderecos = new List<Models.Endereco>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = "SELECT pro.id_professor AS id_professor, pro.nome as nome, pro.cpf as cpf, pro.data_nascimento as data_nascimento, pro.sexo as sexo, pro.telefone as telefone, log.email as email, pro.formacao as formacao, pro.createdAt as data_criacao, ende.rua as rua, ende.numero as numero, ende.complemento as complemento, ende.cidade as cidade, ende.cep as cep, ufs.nome as nomeestado, ufs.pais as pais, ufs.sigla as sigla FROM Professores AS pro LEFT JOIN Enderecos AS ende ON (pro.id_endereco=ende.id_endereco) LEFT JOIN Ufs AS ufs ON (ende.id_uf=ufs.id_uf) LEFT JOIN Login AS log ON (pro.id_login=log.id_login) where ativo = 1";

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Models.Professor professor = new Models.Professor();
                        professor.Id = (int)dr["id_professor"];
                        professor.Nome = dr["nome"].ToString();
                        professor.Cpf = dr["cpf"].ToString();
                        professor.Email = dr["email"].ToString();
                        professor.Formacao = dr["formacao"].ToString();
                        professor.DataCriacao = (DateTime)dr["data_criacao"];
                        professor.DataNascimento = (DateTime)dr["data_nascimento"];
                        professor.Sexo = dr["sexo"].ToString();
                        professor.Telefone = dr["telefone"].ToString();

                        professores.Add(professor);

                        Models.Endereco endereco = new Endereco();
                        endereco.Rua = dr["rua"].ToString();
                        endereco.Numero = dr["numero"].ToString();
                        endereco.Complemento = dr["complemento"].ToString();
                        endereco.Cidade = dr["cidade"].ToString();
                        endereco.Estado = dr["nomeestado"].ToString();
                        endereco.Pais = dr["pais"].ToString();
                        endereco.Sigla = dr["sigla"].ToString();

                        enderecos.Add(endereco);

                    }
                }
                alunoEnderecoLogins.Professor = professores;
                alunoEnderecoLogins.Endereco = enderecos;
            }

            return alunoEnderecoLogins;
        }



        public Models.ProfessorEnderecos listarProf(int id)
        {
            Models.ProfessorEnderecos alunoEnderecoLogins = new Models.ProfessorEnderecos();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = "SELECT pro.id_professor AS id_professor, log.id_login as id_login, ende.id_endereco as id_endereco, pro.nome as nome, pro.cpf as cpf, pro.data_nascimento as data_nascimento, pro.sexo as sexo, pro.telefone as telefone, log.email as email, pro.formacao as formacao, pro.createdAt as data_criacao, ende.rua as rua, ende.numero as numero, ende.complemento as complemento, ende.cidade as cidade, ende.cep as cep, ufs.nome as nomeestado, ufs.pais as pais, ufs.sigla as sigla FROM Professores AS pro LEFT JOIN Enderecos AS ende ON (pro.id_endereco=ende.id_endereco) LEFT JOIN Ufs AS ufs ON (ende.id_uf=ufs.id_uf) LEFT JOIN Login AS log ON (pro.id_login=log.id_login) where id_professor = @id";

                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;
                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.Read())
                    {
                        Models.Professor professor = new Models.Professor();
                        professor.Id = (int)dr["id_professor"];
                        professor.IdLogin = (int)dr["id_login"];
                        professor.Nome = dr["nome"].ToString();
                        professor.Cpf = dr["cpf"].ToString();
                        professor.DataNascimento = (DateTime)dr["data_nascimento"];
                        professor.Email = dr["email"].ToString();
                        professor.Sexo = dr["sexo"].ToString();
                        professor.Formacao = dr["formacao"].ToString();
                        professor.Telefone = dr["telefone"].ToString();


                        Models.Endereco endereco = new Endereco();
                        endereco.Id = (int)dr["id_endereco"];
                        endereco.Rua = dr["rua"].ToString();
                        endereco.Numero = dr["numero"].ToString();
                        endereco.Complemento = dr["complemento"].ToString();
                        endereco.Cidade = dr["cidade"].ToString();
                        endereco.Estado = dr["nomeestado"].ToString();
                        endereco.Pais = dr["pais"].ToString();
                        endereco.Sigla = dr["sigla"].ToString();

                        alunoEnderecoLogins.Professor = professor;
                        alunoEnderecoLogins.Endereco = endereco;
                    }
                }
            }

            return alunoEnderecoLogins;
        }


        public void atualizarProfessores(Models.ProfessorEnderecos profEnderecos)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = "UPDATE Enderecos SET rua = @rua, numero = @numero, complemento = @complemento, cidade = @cidade, cep = @cep where id_endereco = @idENDERECO;";

                    command.Parameters.Add(new SqlParameter("@idENDERECO", System.Data.SqlDbType.Int)).Value = profEnderecos.Endereco.Id;
                    command.Parameters.Add(new SqlParameter("@rua", System.Data.SqlDbType.VarChar)).Value = profEnderecos.Endereco.Rua;
                    command.Parameters.Add(new SqlParameter("@numero", System.Data.SqlDbType.VarChar)).Value = profEnderecos.Endereco.Numero;
                    command.Parameters.Add(new SqlParameter("@complemento", System.Data.SqlDbType.VarChar)).Value = profEnderecos.Endereco.Complemento;
                    command.Parameters.Add(new SqlParameter("@cidade", System.Data.SqlDbType.VarChar)).Value = profEnderecos.Endereco.Cidade;
                    command.Parameters.Add(new SqlParameter("@cep", System.Data.SqlDbType.VarChar)).Value = profEnderecos.Endereco.Cep;
                    command.ExecuteScalar();


                    command.CommandText = "UPDATE Login SET email = @email where id_login = @idLOGIN;";
                    command.Parameters.Add(new SqlParameter("@idLOGIN", System.Data.SqlDbType.Int)).Value = profEnderecos.Professor.IdLogin;
                    command.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.VarChar)).Value = profEnderecos.Professor.Email;
                    command.ExecuteScalar();


                    command.CommandText = "UPDATE Professores set nome = @nome, cpf = @cpf, sexo = @sexo, telefone = @telefone, formacao = @formacao WHERE id_professor = @idPROFESSOR";

                    command.Parameters.Add(new SqlParameter("@idPROFESSOR", System.Data.SqlDbType.Int)).Value = profEnderecos.Professor.Id;
                    command.Parameters.Add(new SqlParameter("@formacao", System.Data.SqlDbType.VarChar)).Value = profEnderecos.Professor.Formacao;

                    command.Parameters.Add(new SqlParameter("@nome", System.Data.SqlDbType.VarChar)).Value = profEnderecos.Professor.Nome;
                    command.Parameters.Add(new SqlParameter("@cpf", System.Data.SqlDbType.VarChar)).Value = profEnderecos.Professor.Cpf;
                    command.Parameters.Add(new SqlParameter("@sexo", System.Data.SqlDbType.VarChar)).Value = profEnderecos.Professor.Sexo;
                    command.Parameters.Add(new SqlParameter("@telefone", System.Data.SqlDbType.VarChar)).Value = profEnderecos.Professor.Telefone;

                    command.ExecuteScalar();
                }
            }
        }



        public void atualizarProfessros(Models.AlunoEndereco alunoEndereco)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = "UPDATE Enderecos SET rua = @rua, numero = @numero, complemento = @complemento, cidade = @cidade, cep = @cep where id_endereco = @idENDERECO;";

                    command.Parameters.Add(new SqlParameter("@idENDERECO", System.Data.SqlDbType.Int)).Value = alunoEndereco.Endereco.Id;
                    command.Parameters.Add(new SqlParameter("@rua", System.Data.SqlDbType.VarChar)).Value = alunoEndereco.Endereco.Rua;
                    command.Parameters.Add(new SqlParameter("@numero", System.Data.SqlDbType.VarChar)).Value = alunoEndereco.Endereco.Numero;
                    command.Parameters.Add(new SqlParameter("@complemento", System.Data.SqlDbType.VarChar)).Value = alunoEndereco.Endereco.Complemento;
                    command.Parameters.Add(new SqlParameter("@cidade", System.Data.SqlDbType.VarChar)).Value = alunoEndereco.Endereco.Cidade;
                    command.Parameters.Add(new SqlParameter("@cep", System.Data.SqlDbType.VarChar)).Value = alunoEndereco.Endereco.Cep;
                    command.ExecuteScalar();


                    command.CommandText = "UPDATE Login SET email = @email where id_login = @idLOGIN;";
                    command.Parameters.Add(new SqlParameter("@idLOGIN", System.Data.SqlDbType.Int)).Value = alunoEndereco.Aluno.IdLogin;
                    command.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.VarChar)).Value = alunoEndereco.Aluno.Email;
                    command.ExecuteScalar();


                    command.CommandText = "UPDATE Alunos set nome = @nome, cpf = @cpf, data_nascimento = @data_nascimento, sexo = @sexo, telefone = @telefone WHERE id_aluno = @idALUNO";

                    command.Parameters.Add(new SqlParameter("@idALUNO", System.Data.SqlDbType.Int)).Value = alunoEndereco.Aluno.Id;
                    command.Parameters.Add(new SqlParameter("@nome", System.Data.SqlDbType.VarChar)).Value = alunoEndereco.Aluno.Nome;
                    command.Parameters.Add(new SqlParameter("@cpf", System.Data.SqlDbType.VarChar)).Value = alunoEndereco.Aluno.Cpf;
                    command.Parameters.Add(new SqlParameter("@data_nascimento", System.Data.SqlDbType.Date)).Value = alunoEndereco.Aluno.DataNascimento;
                    command.Parameters.Add(new SqlParameter("@sexo", System.Data.SqlDbType.VarChar)).Value = alunoEndereco.Aluno.Sexo;
                    command.Parameters.Add(new SqlParameter("@telefone", System.Data.SqlDbType.VarChar)).Value = alunoEndereco.Aluno.Telefone;

                    command.ExecuteScalar();
                }
            }
        }

        public List<Models.Duvida> listarDuvidas()
        {
            List<Models.Duvida> duvidas = new List<Models.Duvida>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = "select f.id_faq as id_faq, p.id_pergunta as id_pergunta, r.id_resposta as id_resposta, p.pergunta as pergunta, r.resposta as resposta, r.email_usuario as email_usuario, p.data_pergunta as data_pergunta from Perguntas as p left join Faq as f on (f.id_pergunta=p.id_pergunta) left join Respostas as r on (r.id_resposta=f.id_resposta) where id_faq is not null";

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Models.Duvida duvida = new Models.Duvida();
                        duvida.IdFaq = dr["id_faq"] != DBNull.Value ? (int)dr["id_faq"] : 0;
                        duvida.IdPergunta = dr["id_pergunta"] != DBNull.Value ? (int)dr["id_pergunta"] : 0;
                        duvida.IdResposta = dr["id_resposta"] != DBNull.Value ? (int)dr["id_resposta"] : 0;
                        duvida.Pergunta = dr["pergunta"].ToString();
                        duvida.Resposta = dr["resposta"].ToString();
                        duvida.Email = dr["email_usuario"].ToString();
                        duvida.DataPergunta = dr["data_pergunta"] != DBNull.Value ? (DateTime)dr["data_pergunta"] : DateTime.MinValue;

                        duvidas.Add(duvida);
                    }
                }
            }
            return duvidas;
        }

        public void responderPergunta(int id, string resposta, string emailUser)
        {
            int idResposta = 0;
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO Respostas (resposta, email_usuario) VALUES (@resposta, @email_usuario); select convert(int,@@identity) as id;;";
                    command.Parameters.Add(new SqlParameter("@resposta", System.Data.SqlDbType.VarChar)).Value = resposta;
                    command.Parameters.Add(new SqlParameter("@email_usuario", System.Data.SqlDbType.VarChar)).Value = emailUser;
                    idResposta = (int)command.ExecuteScalar();

                    command.CommandText = "update Faq SET id_resposta = @id_resposta WHERE id_pergunta = @id_pergunta";
                    command.Parameters.Add(new SqlParameter("@id_resposta", System.Data.SqlDbType.VarChar)).Value = idResposta;
                    command.Parameters.Add(new SqlParameter("@id_pergunta", System.Data.SqlDbType.VarChar)).Value = id;

                    command.ExecuteScalar();
                }
            }
        }


        public void deletarDuvida(int idFaq)
        {
            int id_Faq = idFaq;
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM Faq where id_faq = @idFaq";
                    command.Parameters.Add(new SqlParameter("@idFaq", System.Data.SqlDbType.Int)).Value = id_Faq;
                    command.ExecuteScalar();
                }
            }
        }

        public void deletarAluno(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "update Alunos set ativo = 0 where id_aluno = @id";
                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;
                    command.ExecuteScalar();
                }
            }
        }

        public void deletarProfessor(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "update Professores set ativo = 0 where id_professor = @id";
                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;
                    command.ExecuteScalar();
                }
            }
        }
    }
}