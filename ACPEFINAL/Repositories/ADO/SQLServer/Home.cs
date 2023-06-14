using ACPEFINAL.Models;
using Microsoft.Data.SqlClient;

namespace ACPEFINAL.Repositories.ADO.SQLServer
{
    public class Home
    {
        private readonly string connectionString;
        public Home(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void enviarPergunta(Models.Duvida duvida)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = "INSERT INTO Perguntas (pergunta, email_usuario) VALUES (@pergunta, @email); select convert(int,@@identity) as id;;";

                    command.Parameters.Add(new SqlParameter("@pergunta", System.Data.SqlDbType.VarChar)).Value = duvida.Pergunta;
                    command.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.VarChar)).Value = duvida.Email;

                    duvida.IdPergunta = (int)command.ExecuteScalar();
                }
            }
        }
    }
}
