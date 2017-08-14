using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTS.Weds.Common
{
   
    public class Utils
    {
        public const string searchQuery = @"select * from   Canditate_Personal cp    
                                        inner join BirthDetails bd
                                        on cp.CandidateId=bd.CandidateId
                                        inner join AddressDetails ad
                                        on cp.CandidateId= ad.CandidateId
                                        inner join EducationDetails ed
                                        on cp.CandidateId= ed.CandidateId
                                        inner join FamilyDetails fd
                                        on cp.CandidateId= fd.CandidateId
                                        inner join ExpectationDetails exd
                                        on cp.CandidateId= exd.CandidateId WHERE ";
    }

   

    public enum CandidateType {

        Bride,
        Groom, 
        Divorcee
    }


    public enum Gender
    {

        Male,
        Female
    }
}
