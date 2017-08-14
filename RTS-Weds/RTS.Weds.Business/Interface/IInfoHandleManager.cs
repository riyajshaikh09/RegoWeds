using RTS.Weds.Business.Model;
using RTS.Weds.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTS.Weds.Business.Interface
{
  public  interface IInfoHandleManager
    {
        CandidateData getAllCandidateData(string candidateType);

        IEnumerable<object> serachAllData(object searchCriteria);

        IEnumerable<object> getCandidateDetails(string candidateId);

        object registerCandidate();

        BirthDetails insertBirthdetails(BirthDetails data);

        AddressDetails insertAddressDetails(AddressDetails data);
        EducationDetails insertEducationDetails(EducationDetails data);
        FamilyDetails insertFamilyetails(FamilyDetails data);
        ExpectationDetails insertExpectationdetails(ExpectationDetails data);

        IEnumerable<CompleteCandidate> getCandidateData(int candidateId, string CandidateType);

        IEnumerable<CompleteCandidate> getSearchedData(SearchRequest searchCriteria);

    }
}
