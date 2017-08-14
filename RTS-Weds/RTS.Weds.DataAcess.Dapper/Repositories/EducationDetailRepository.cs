
using RTS.Weds.Common;
using RTS.Weds.DataAcess.Dapper.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTS.Weds.DataAcess.Dapper.Repositories
{
  public class EducationDetailRepository : Repository<EducationDetails>,IEducationDetailsRepository
    {
       

        public override IEnumerable<EducationDetails> GetAll()
        {
            return base.GetAll();
        }

        public IEnumerable<object> getDataUsingQuery(string query)

        {
            return base.GetDataUsingQuery<object>(query);
        }

       

        public EducationDetails insertBirthDetails(EducationDetails item)
        {
            return base.Add(item);
        }

        public Common.EducationDetails insertEducationDetails(Common.EducationDetails item)
        {
            return base.Add(item);
        }
    }
}
