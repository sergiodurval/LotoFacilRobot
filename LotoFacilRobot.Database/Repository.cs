using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LotoFacilRobot.Database.Interface;
namespace LotoFacilRobot.Database
{
    public class Repository<T> : IRepository<T> where T : class
    {

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById()
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateById(T entity, int key)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(T entity, int key)
        {
            throw new NotImplementedException();
        }
    }
}
