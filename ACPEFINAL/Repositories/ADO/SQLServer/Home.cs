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


        public List<Duvida> exibirDuvidas()
        {
            List<Duvida> duvidas = new List<Duvida>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = "select pergunta, resposta from faq as f inner join Perguntas as p on  p.id_pergunta=f.id_pergunta inner join Respostas as r on r.id_resposta=f.id_resposta";

                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        Models.Duvida duvida = new Models.Duvida();
                        duvida.Pergunta = dr["pergunta"].ToString();
                        duvida.Resposta = dr["resposta"].ToString();

                        duvidas.Add(duvida);
                    }
                }
            }

            return duvidas;
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
