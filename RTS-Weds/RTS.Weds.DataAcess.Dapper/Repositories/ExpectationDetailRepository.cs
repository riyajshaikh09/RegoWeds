
using RTS.Weds.Common;
using RTS.Weds.DataAcess.Dapper.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTS.Weds.DataAcess.Dapper.Repositories
{
  public class ExpectationDetailRepository : Repository<ExpectationDetails>,IExpectationsDetailsRepository
    {
       

        public override IEnumerable<ExpectationDetails> GetAll()
        {
            return base.GetAll();
        }

        public IEnumerable<object> getDataUsingQuery(string query)

        {
            return base.GetDataUsingQuery<object>(query);
        }



        public ExpectationDetails insertExpectationDetails(ExpectationDetails item)
        {
            return base.Add(item);
        }
    }
}
