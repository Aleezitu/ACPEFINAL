using Microsoft.Data.SqlClient;

namespace ACPEFINAL.Repositories.ADO.SQLServer
{
    public class Login
    {
        private readonly string connectionString;
        public Login(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool check(Models.Login login)
        {
            bool result = false;

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT id_login FROM Login WHERE email = @email AND senha = @senha";
                    command.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.VarChar)).Value = login.Email;
                    command.Parameters.Add(new SqlParameter("@senha", System.Data.SqlDbType.VarChar)).Value = Configurations.Hash.CriarHash(login.Senha);

                    SqlDataReader dr = command.ExecuteReader();
                    result = dr.Read();
                }
            }

            return result;
        }
        public int getType(Models.Login login)
        {
            int idTipoUsuario = 0;

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT CASE WHEN alu.id_tipo_usuario IS NOT NULL THEN alu.id_tipo_usuario WHEN pro.id_tipo_usuario IS NOT NULL THEN pro.id_tipo_usuario ELSE adm.id_tipo_usuario END AS id_tipo_usuario, CASE WHEN alu.id_tipo_usuario IS NOT NULL THEN alu.id_aluno WHEN pro.id_tipo_usuario IS NOT NULL THEN pro.id_professor ELSE adm.id_admin END AS id_usuario FROM Login AS log LEFT JOIN Alunos AS alu ON log.id_login = alu.id_login LEFT JOIN Professores AS pro ON log.id_login = pro.id_login LEFT JOIN Admins AS adm ON log.id_login = adm.id_login WHERE log.id_login = ( SELECT id_login FROM Login WHERE email = @email AND senha = @senha )";
                    command.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.VarChar)).Value = login.Email;
                    command.Parameters.Add(new SqlParameter("@senha", System.Data.SqlDbType.VarChar)).Value = Configurations.Hash.CriarHash(login.Senha);

                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.Read())
                    {
                        //idTipoUsuario = dr.GetInt32(0);
                        idTipoUsuario = (int)dr["id_tipo_usuario"];
                        login.TipoUsuario = idTipoUsuario;
                        login.Id = (int)dr["id_usuario"];
                    }

                    dr.Close();
                }
            }

            return idTipoUsuario;
        }



    }
}
