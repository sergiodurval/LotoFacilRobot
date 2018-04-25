using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoFacilRobot.Database.Interface
{
    interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById();
        void Insert(TEntity entity);
        void UpdateById(TEntity entity, int key);
        void Delete(TEntity entity);
        void DeleteById(TEntity entity, int key);
    }
}
