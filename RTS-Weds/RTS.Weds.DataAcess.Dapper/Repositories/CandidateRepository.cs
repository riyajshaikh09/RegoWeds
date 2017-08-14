
using RTS.Weds.Common;
using RTS.Weds.DataAcess.Dapper.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTS.Weds.DataAcess.Dapper.Repositories
{
  public class CandidateRepository : Repository<Canditate_Personal>, ICandidateRepository
    {
        public void AddCandidate(Canditate_Personal item)
        {
            base.Add(item); 
        }

        public override IEnumerable<Canditate_Personal> GetAll()
        {
            return base.GetAll();
        }

        public IEnumerable<CompleteCandidate> getCandidateData(int candidateId, string CandidateType)
        {
            Dictionary<string, object> inputParams = new Dictionary<string, object>();
            inputParams.Add("candidateId", candidateId);
            inputParams.Add("CandidateType", CandidateType);

            return base.RunSP<CompleteCandidate>("proc_getCandidateData", inputParams);
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
        public Canditate_Personal insertCandidatePersonalDetails(Canditate_Personal item)
        {
         return base.Add(item);
        }

        public IEnumerable<CompleteCandidate> getSearchedData(SearchRequest searchCriteria)
        {
            string query = buildQuery(searchCriteria);

            return   base.GetDataUsingQuery<CompleteCandidate>(query);
           
        }

        private string buildQuery(SearchRequest searchCriteria)
        {
            string query =Utils.searchQuery;
            StringBuilder subQuery = new StringBuilder();

            if (searchCriteria.CandidateId > 0) {
                subQuery.Append("AND cp.CandidateId=" + searchCriteria.CandidateId);
            }

            if (!string.IsNullOrEmpty(searchCriteria.Gender))
            {
                subQuery.Append(string.Format("AND cp.Gender= '{0}'", searchCriteria.Gender));
            }

            if (!string.IsNullOrEmpty(searchCriteria.MaritialStatus))
            {
                subQuery.Append(string.Format("AND cp.MaritialStatus='{0}'" , searchCriteria.MaritialStatus));
            }
            if (!string.IsNullOrEmpty(searchCriteria.Residence))
            {
                subQuery.Append( string.Format("AND ad.ResidentAddress LIKE '%{0}%'", searchCriteria.Residence));
            }

            if (!string.IsNullOrEmpty(searchCriteria.BirthYear))
            {
                subQuery.Append(string.Format("AND bd.DateOfBirth LIKE '%{0}%'", searchCriteria.BirthYear));
            }
            string querySub = subQuery.ToString();
            if (querySub.StartsWith("AND"))
                querySub = querySub.TrimStart("AND".ToCharArray());

            query = query + querySub;

            if (query.EndsWith("WHERE "))
                query = query.TrimEnd("WHERE ".ToCharArray());


            return query;
        }
    }
}



