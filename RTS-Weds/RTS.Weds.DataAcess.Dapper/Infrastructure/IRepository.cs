using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTS.Weds.DataAcess.Dapper.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : class
    {
     
        IEnumerable<TEntity> GetAll();
        TEntity Add(TEntity entity);
       
        void Update(TEntity entity);
    }
}
