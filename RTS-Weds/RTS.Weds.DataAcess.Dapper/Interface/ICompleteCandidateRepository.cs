using RTS.Weds.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTS.Weds.DataAcess.Dapper.Interface
{
   public interface ICandidateRepository
    {
        void AddCandidate(Canditate_Personal item);
        IEnumerable<Canditate_Personal> GetAll();
        IEnumerable<object> getDataUsingQuery(string query);

        object registerCandidate();

        Canditate_Personal insertCandidatePersonalDetails(Canditate_Personal item);

     



    }
}
