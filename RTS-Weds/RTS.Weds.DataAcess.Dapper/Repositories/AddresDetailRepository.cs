    
using RTS.Weds.Common;
using RTS.Weds.DataAcess.Dapper.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTS.Weds.DataAcess.Dapper.Repositories
{
  public class BirthRepository : Repository<BirthDetail>, IBirthDetailsRepository
    {
       

        public override IEnumerable<BirthDetail> GetAll()
        {
            return base.GetAll();
        }

        public IEnumerable<object> getDataUsingQuery(string query)

        {
            return base.GetDataUsingQuery<object>(query);
        }

        public object registerCandidate()
        {
            Dictionary<string, object> lst = new Dictionary<string, object>();
            lst.Add("FirstName", "Aslam11");
            lst.Add("LastName", "Mujawar1");
            lst.Add("Gender", "Male");
            lst.Add("ResAddress", "Karkambh, Pandharpur");
            return base.RunSP<Canditate_Personal>("procInsert_CandidateData", lst);
          //  throw new NotImplementedException();
        }

        public BirthDetail insertBirthDetails(BirthDetail item)
        {
            return base.Add(item);
        }
    }
}
