using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LotoFacilRobot.Domain.Model;
using System.Data.SqlClient;
namespace LotoFacilRobot.Database
{
    public class ConcursoDAO
    {
        public string strConnection = ConfigurationManager.ConnectionStrings["LotoFacilDBConnection"].ConnectionString;
        public SqlConnection conn;

        public List<Concurso> GetAll()
        {
            try
            {
                List<Concurso> ListaConcursos = new List<Concurso>();
                using(conn = new SqlConnection(strConnection))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM concurso", conn);
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Concurso concurso = new Concurso();
                        concurso.IdConcurso = Convert.ToInt32(reader["IdConcurso"]);
                        concurso.NumeroConcurso = Convert.ToInt32(reader["NumeroConcurso"]);
                        concurso.NumerosSorteados = PopulateNumerosSorteados(reader["NumerosSorteados"].ToString());
                        concurso.PremioEstimado = Convert.ToDouble(reader["PremioEstimado"]);
                        concurso.ProximoConcurso = Convert.ToDateTime(reader["ProximoConcurso"]);
                        concurso.DataResultado = Convert.ToDateTime(reader["DataResultado"]);
                        ListaConcursos.Add(concurso);
                    }
                    conn.Close();
                    return ListaConcursos;
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
            }
        }

        public int InsertConcurso(Concurso concurso)
        {
            int id = 0;
            try
            {
                using (conn = new SqlConnection(strConnection))
                {
                    SqlCommand command = new SqlCommand("INSERT INTO concurso(NumeroConcurso,DataResultado,"+
                    "PremioEstimado,NumerosSorteados,ProximoConcurso) values(@NumeroConcurso,@DataResultado,"+
                    "@PremioEstimado,@NumerosSorteados,@ProximoConcurso);SELECT SCOPE_IDENTITY()", conn);
                    command.Parameters.Add("@NumeroConcurso",concurso.NumeroConcurso);
                    command.Parameters.Add("@DataResultado",concurso.DataResultado);
                    command.Parameters.Add("@PremioEstimado",concurso.PremioEstimado);
                    command.Parameters.Add("@NumerosSorteados",string.Join("-",concurso.NumerosSorteados));
                    command.Parameters.Add("@ProximoConcurso",concurso.ProximoConcurso);
                    conn.Open();
                    id = Convert.ToInt32(command.ExecuteScalar());
                    conn.Close();
                    return id;
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
            }
        }

        public List<int> PopulateNumerosSorteados(string numeros)
        {
            List<int> ListaNumerosSorteados = new List<int>();
            for (int i = 0; i <= numeros.Length; i++)
            {
                ListaNumerosSorteados.Add(Convert.ToInt32(i));
            }
            return ListaNumerosSorteados;
        }
    }
}
