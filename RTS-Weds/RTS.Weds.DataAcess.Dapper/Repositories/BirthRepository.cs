
using RTS.Weds.Common;
using RTS.Weds.DataAcess.Dapper.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTS.Weds.DataAcess.Dapper.Repositories
{
  public class BirthRepository : Repository<BirthDetails>, IBirthDetailsRepository
    {
       

        public override IEnumerable<BirthDetails> GetAll()
        {
            return base.GetAll();
        }

        public IEnumerable<object> getDataUsingQuery(string query)

        {
            return base.GetDataUsingQuery<object>(query);
        }

      
        public BirthDetails insertBirthDetails(BirthDetails item)
        {
            return base.Add(item);
        }
    }
}
