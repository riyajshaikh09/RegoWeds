using RTS.Weds.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RTS.Weds.Services.Interface
{
    interface IInfoHandle
    {
        HttpResponseMessage getAllCandidateData(string candidateType );
     
        IEnumerable<object> serachAllData(object searchCriteria);

        IEnumerable<object> getCandidateDetails(string candidateId);

        HttpResponseMessage registerCandidate();
        HttpResponseMessage insertPersonalDetails(Canditate_Personal candidatePersonalData);

        HttpResponseMessage insertBirthdetails(BirthDetails data);

        HttpResponseMessage insertAddressDetails(AddressDetails data);
        HttpResponseMessage insertEducationDetails(EducationDetails data);
        HttpResponseMessage insertFamilyetails(FamilyDetails data);
        HttpResponseMessage insertExpectationdetails(ExpectationDetails data);

        HttpResponseMessage getCandidateData(int candidateId , string candidateType);

        HttpResponseMessage getSearchedData(SearchRequest searchCriteria);
    }
}
