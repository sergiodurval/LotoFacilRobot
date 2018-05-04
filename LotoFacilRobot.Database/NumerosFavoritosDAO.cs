using LotoFacilRobot.Domain.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoFacilRobot.Database
{
    public class NumerosFavoritosDAO
    {
        public string strConnection = ConfigurationManager.ConnectionStrings["LotoFacilDBConnection"].ConnectionString;
        public SqlConnection conn;

        public void InsertNumerosFavoritos(NumerosFavoritos numerosFavoritos)
        {
            try
            {
                using (conn = new SqlConnection(strConnection))
                {
                    SqlCommand command = new SqlCommand("PR_INSERT_NUMEROS_FAVORITOS",conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NumerosFavoritos",string.Join("-",numerosFavoritos.ListaNumerosFavoritos));
                    command.Parameters.AddWithValue("@Ativo", numerosFavoritos.Ativo);
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
            }
        }

        public DataTable GetAllNumerosFavoritos()
        {
            try
            {
                using (conn = new SqlConnection(strConnection))
                {
                    SqlCommand command = new SqlCommand("PR_GET_ALL_NUMEROS_FAVORITOS", conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                    da.Dispose();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
            }
        }

        public List<int> GetAllNumerosFavoritosInList()
        {
            List<int> numerosFavoritos = new List<int>();
            try
            {
                using (conn = new SqlConnection(strConnection))
                {
                    SqlCommand command = new SqlCommand("PR_GET_ALL_NUMEROS_FAVORITOS", conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        numerosFavoritos = reader["NumerosFavoritos"].ToString().Split('-').Select(Int32.Parse).ToList();
                    }
                    command.Dispose();
                    reader.Dispose();
                    return numerosFavoritos;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
            }
        }
    }
}
