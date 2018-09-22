using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LotoFacilRobot.Domain.Model;
using System.Data.SqlClient;
using System.Data;
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
                    SqlCommand command = new SqlCommand("PR_GET_ALL_CONCURSOS", conn);
                    command.CommandType = CommandType.StoredProcedure;
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
                    SqlCommand command = new SqlCommand("PR_INSERT_CONCURSO", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NumeroConcurso",concurso.NumeroConcurso);
                    command.Parameters.AddWithValue("@DataResultado",concurso.DataResultado);
                    command.Parameters.AddWithValue("@PremioEstimado",concurso.PremioEstimado);
                    command.Parameters.AddWithValue("@NumerosSorteados",string.Join("-",concurso.NumerosSorteados));
                    command.Parameters.AddWithValue("@ProximoConcurso",concurso.ProximoConcurso);
                    command.Parameters.AddWithValue("@IdConcursoGerado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    conn.Open();
                    command.ExecuteNonQuery();
                    id = Convert.ToInt32(command.Parameters["@IdConcursoGerado"].Value);
                    command.Dispose();
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
            ListaNumerosSorteados = numeros.Split('-').Select(Int32.Parse).ToList();
            return ListaNumerosSorteados;
           
        }

        public int GetNumeroUltimoConcursoExtracao()
        {
            int ultimoConcurso = 0;
            try
            {
                using (conn = new SqlConnection(strConnection))
                {
                    SqlCommand command = new SqlCommand("PR_GET_NUMEROCONCURSO_EXTRAIDO", conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NumeroConcurso", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                    conn.Open();
                    command.ExecuteNonQuery();
                    ultimoConcurso = Convert.ToInt32(command.Parameters["@NumeroConcurso"].Value);
                    conn.Close();
                }
                return ultimoConcurso;
            }
            catch (Exception ex)
            {
                
                throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
            }
        }

        public DataTable GetConcursos()
        {
            try
            {
                using (conn = new SqlConnection(strConnection))
                {
                    SqlCommand command = new SqlCommand("PR_GET_ALL_CONCURSOS", conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    conn.Open();
                    da.Fill(dt);
                    command.Dispose();
                    da.Dispose();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
            }
        }

        public List<int> GetResultadoConcursoByNumeroConcurso(int numeroConcurso)
        {
            List<int> listaNumerosSorteados = new List<int>();
            try
            {
                using (conn = new SqlConnection(strConnection))
                {
                    SqlCommand command = new SqlCommand("PR_GET_CONCURSO_BY_NUMEROCONCURSO", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NumeroConcurso", numeroConcurso);
                    conn.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        listaNumerosSorteados = dr["NumerosSorteados"].ToString().Split('-').Select(Int32.Parse).ToList();
                    }
                    command.Dispose();
                    return listaNumerosSorteados;
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
            }
        }

        public int GetNumeroUltimoConcurso()
        {
            int numeroConcurso = 0;
            try
            {
                using (conn = new SqlConnection(strConnection))
                {
                    SqlCommand command = new SqlCommand("PR_GET_ULTIMO_CONCURSO", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        numeroConcurso = Convert.ToInt32(reader["NumeroConcurso"]);
                    }
                    conn.Close();
                    command.Dispose();
                    return numeroConcurso;
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
            }
        }

        public DateTime GetDataResultadoConcurso(int numeroConcurso)
        {
            DateTime dataResultado = new DateTime();
            try
            {
                using (conn = new SqlConnection(strConnection))
                {
                    SqlCommand command = new SqlCommand("PR_GET_DATARESULTADO_BY_NUMEROCONCURSO", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NumeroConcurso", numeroConcurso);
                    conn.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        dataResultado = Convert.ToDateTime(dr["DataResultado"]);
                    }
                    conn.Close();
                    command.Dispose();
                    return dataResultado;
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
            }
        }
    }
}
