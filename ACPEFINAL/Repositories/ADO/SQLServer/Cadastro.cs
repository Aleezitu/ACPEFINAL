using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace ACPEFINAL.Repositories.ADO.SQLServer
{
    public class Cadastro
    {
        private readonly string connectionString;
        public Cadastro(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void cadastrar(Models.Admin admin)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    
                    command.CommandText = "INSERT INTO Login(email, senha) values(@email, @senha); select convert(int,@@identity) as id;;";

                    command.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.VarChar)).Value = admin.Email;
                    command.Parameters.Add(new SqlParameter("@senha", System.Data.SqlDbType.VarChar)).Value = Configurations.Hash.CriarHash(admin.Senha);

                    int idLogin = (int)command.ExecuteScalar();

                    command.CommandText = "INSERT INTO Admins (nome, cpf, telefone, id_login, id_tipo_usuario) values (@nome, @cpf, @telefone, @idLogin, @id_tipo_usuario); select convert(int,@@identity) as id;;";

                    command.Parameters.Add(new SqlParameter("@nome", System.Data.SqlDbType.VarChar)).Value = admin.Nome;
                    command.Parameters.Add(new SqlParameter("@cpf", System.Data.SqlDbType.VarChar)).Value = admin.Cpf;
                    command.Parameters.Add(new SqlParameter("@telefone", System.Data.SqlDbType.VarChar)).Value = admin.Telefone;
                    command.Parameters.Add(new SqlParameter("@idLogin", System.Data.SqlDbType.VarChar)).Value = idLogin;
                    command.Parameters.Add(new SqlParameter("@id_tipo_usuario", System.Data.SqlDbType.VarChar)).Value = 1;

                    admin.Id = (int)command.ExecuteScalar();
                }
            }
        }
    }
}
