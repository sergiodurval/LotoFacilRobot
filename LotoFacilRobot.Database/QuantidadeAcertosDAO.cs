using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LotoFacilRobot.Domain.Model;
namespace LotoFacilRobot.Database
{
    public class QuantidadeAcertosDAO
    {
        public string strConnection = ConfigurationManager.ConnectionStrings["LotoFacilDBConnection"].ConnectionString;
        public SqlConnection conn;

        public void InsertQuantidadeAcertos(QuantidadeAcertos qtdAcertos)
        {
            try
            {
                using (conn = new SqlConnection(strConnection))
                {
                    SqlCommand command = new SqlCommand("INSERT INTO QuantidadeAcertos(IdConcurso,QuinzeAcertos,"+
                    "QuatorzeAcertos,TrezeAcertos,DozeAcertos,OnzeAcertos,ValorPremioQuinzeAcertos,"+
                    "ValorPremioQuatorzeAcertos,ValorPremioTrezeAcertos,ValorPremioDozeAcertos,ValorPremioOnzeAcertos"+
                    ")values(@IdConcurso,@QuinzeAcertos," +
                    "@QuatorzeAcertos,@TrezeAcertos,@DozeAcertos,@OnzeAcertos,@ValorPremioQuinzeAcertos,"+
                    "@ValorPremioQuatorzeAcertos,@ValorPremioTrezeAcertos,@ValorPremioDozeAcertos,@ValorPremioOnzeAcertos)", conn);
                    command.Parameters.Add("@IdConcurso", qtdAcertos.IdConcurso);
                    command.Parameters.Add("@QuinzeAcertos", qtdAcertos.QuinzeAcertos);
                    command.Parameters.Add("@QuatorzeAcertos", qtdAcertos.QuatorzeAcertos);
                    command.Parameters.Add("@TrezeAcertos", qtdAcertos.TrezeAcertos);
                    command.Parameters.Add("@DozeAcertos", qtdAcertos.DozeAcertos);
                    command.Parameters.Add("@OnzeAcertos", qtdAcertos.OnzeAcertos);
                    command.Parameters.Add("@ValorPremioQuinzeAcertos", qtdAcertos.ValorPremioQuinzeAcertos);
                    command.Parameters.Add("@ValorPremioQuatorzeAcertos", qtdAcertos.ValorPremioQuatorzeAcertos);
                    command.Parameters.Add("@ValorPremioTrezeAcertos", qtdAcertos.ValorPremioTrezeAcertos);
                    command.Parameters.Add("@ValorPremioDozeAcertos", qtdAcertos.ValorPremioDozeAcertos);
                    command.Parameters.Add("@ValorPremioOnzeAcertos", qtdAcertos.ValorPremioOnzeAcertos);
                    conn.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception("Ocorreu o seguinte erro: " + ex.Message);
            }
        }
    }
}
