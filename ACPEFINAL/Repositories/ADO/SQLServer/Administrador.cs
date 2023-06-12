﻿using ACPEFINAL.Models;
using Microsoft.Data.SqlClient;
using NuGet.Protocol.Plugins;
using System.Collections.Generic;

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

                    command.CommandText = "SELECT alu.id_aluno as id_aluno, ende.rua as rua, ende.numero as numero, ende.complemento as complemento, ende.cidade as cidade, ende.cep as cep, alu.nome as nome, alu.cpf as cpf, alu.data_nascimento as data_nascimento, alu.createdAt as data_criacao, alu.sexo as sexo, alu.telefone as telefone, log.email as email, ufs.nome as nomeestado, ufs.pais as pais, ufs.sigla as sigla FROM Alunos AS alu LEFT JOIN Login as log ON (log.id_login=alu.id_login) LEFT JOIN Enderecos AS ende ON (ende.id_endereco=alu.id_endereco) LEFT JOIN Ufs as ufs ON (ufs.id_uf=ende.id_uf) ";

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Models.Aluno aluno = new Models.Aluno();
                        aluno.Id = (int)dr["id_aluno"];
                        aluno.Nome = dr["nome"].ToString();
                        aluno.Cpf = dr["cpf"].ToString();
                        aluno.Email = dr["email"].ToString();
                        aluno.DataNascimento = (DateTime)dr["data_nascimento"];
                        aluno.Sexo = dr["sexo"].ToString();
                        aluno.Telefone = dr["telefone"].ToString();
                        aluno.DataCriacao = (DateTime)dr["data_criacao"];

                        alunos.Add(aluno);

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
                alunoEnderecoLogins.Aluno = alunos;
                alunoEnderecoLogins.Endereco = enderecos;
            }

            return alunoEnderecoLogins;
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

                    command.CommandText = "SELECT pro.id_professor AS id_professor, pro.nome as nome, pro.cpf as cpf, pro.data_nascimento as data_nascimento, pro.sexo as sexo, pro.telefone as telefone, log.email as email, pro.formacao as formacao, pro.createdAt as data_criacao, ende.rua as rua, ende.numero as numero, ende.complemento as complemento, ende.cidade as cidade, ende.cep as cep, ufs.nome as nomeestado, ufs.pais as pais, ufs.sigla as sigla FROM Professores AS pro LEFT JOIN Enderecos AS ende ON (pro.id_endereco=ende.id_endereco) LEFT JOIN Ufs AS ufs ON (ende.id_uf=ufs.id_uf) LEFT JOIN Login AS log ON (pro.id_login=log.id_login)";

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Models.Professor professor = new Models.Professor();
                        professor.Id = (int)dr["id_professor"];
                        professor.Nome = dr["nome"].ToString();
                        professor.Cpf = dr["cpf"].ToString();
                        professor.Email = dr["email"].ToString();
                        professor.DataCriacao = (DateTime)dr["data_criacao"];
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

    }
}