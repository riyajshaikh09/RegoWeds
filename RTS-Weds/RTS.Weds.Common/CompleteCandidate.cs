using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTS.Weds.Common
{
  public  class CompleteCandidate : Canditate_Personal
    {
        public int CandidateBirthDetailsId { get; set; }
        public string DateOfBirth { get; set; }
        public string TimeOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }

        public int CandidateEducationId { get; set; }
        public string QualificationType { get; set; }
        public string Qualification { get; set; }
        public string Occupation { get; set; }
        public string Salary { get; set; }
        public string OccupationCityCountry { get; set; }

        public int CandidateExpectationDetailsId { get; set; }
        public string ExpHeight  { get; set; }
        public string Surmane { get; set; }
        public string OccupationAndIncome { get; set; }
        public string Education { get; set; }
        public string AgeDiffrence { get; set; }
        public string CitiesArea { get; set; }


        public int CandidateFamilyDetailsId { get; set; }
        public string Father { get; set; }
        public string Mother { get; set; }
        public string Brothers { get; set; }
        public string Sisters { get; set; }
        public string MarriedBrothers { get; set; }
        public string MarriedSisters { get; set; }
        public string RelativeSurnames { get; set; }
        public string ParentOccupation { get; set; }
        public string FamilyProperty { get; set; }

        public int CandidateAddressId { get; set; }
        public string ResidentAddress { get; set; }
        public string PermenentAddress { get; set; }
        public string CanctactNo1 { get; set; }

        public string CanctactNo2 { get; set; }
        public string EmailId { get; set; }
    }
}
