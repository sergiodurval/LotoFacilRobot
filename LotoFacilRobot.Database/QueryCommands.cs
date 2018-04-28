using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LotoFacilRobot.Database
{
    /// <summary>
    /// Está classe gera comandos sql através dos objetos
    /// </summary>
    public static class QueryCommands
    {
        private static string IdPropertyName;
        
        /// <summary>
        /// Gera uma query sql que retorna todos os itens de uma tabela
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>string de consulta sql</returns>
        public static string CreateCommandGetAll(object obj)
        {
            return string.Format("select * from {0}", obj.GetType().Name);
        }

        /// <summary>
        /// Gera uma query sql que retorna um item especifico da tabela 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>string de consulta sql</returns>
        public static string CreateCommandGetById(object obj)
        {
            IdPropertyName = SetIdPropertyName(obj);
            return string.Format("select * from {0} where {1} = {2}", 
                obj.GetType().Name,
                obj.GetType().GetProperty(IdPropertyName).Name,
                obj.GetType().GetProperty(IdPropertyName).GetValue(obj,null));
        }

        /// <summary>
        /// Gera uma query sql que cria um comando de insert para uma tabela
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>string de insert sql</returns>
        public static string CreateCommandInsert(object obj)
        {
            StringBuilder command = new StringBuilder();
            command.Append(string.Format("insert into {0} (", obj.GetType().Name));
            //columns
            foreach (PropertyInfo propertyInfo in obj.GetType().GetProperties())
            {
                if (propertyInfo.Name != "IdConcurso")
                {
                    command.Append(propertyInfo.Name);
                    command.Append(",");
                }

            }
            command.Remove(command.Length - 1, 1);
            command.Append(") values(");

            //values
            foreach (PropertyInfo propertyInfo in obj.GetType().GetProperties())
            {
                if (propertyInfo.PropertyType == typeof(List<int>))
                {
                    List<int> Lista = new List<int>();
                    Lista = (List<int>)obj.GetType().GetProperty(propertyInfo.Name).GetValue(obj, null);
                    command.Append(string.Join("-", Lista));
                    command.Append(",");
                }
                else if(propertyInfo.Name != "IdConcurso")
                {
                    command.Append(obj.GetType().GetProperty(propertyInfo.Name).GetValue(obj, null));
                    command.Append(",");
                }

            }
            command.Remove(command.Length - 1, 1);
            command.Append(")");
            return command.ToString();
        }

        /// <summary>
        /// Set o valor do nome da propriedade id do objeto
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>retorna o nome da propriedade id</returns>
        public static string SetIdPropertyName(object obj)
        {
            IdPropertyName = obj.GetType().GetProperty("IdConcurso").Name.ToString();
            return IdPropertyName;
        }

    }
}
