//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RTS.Weds.DataAcess
{
    using System;
    using System.Collections.Generic;
    
    public partial class EducationDetail
    {
        public int CandidateEducationId { get; set; }
        public string QualificationType { get; set; }
        public string Qualification { get; set; }
        public string Occupation { get; set; }
        public string Salary { get; set; }
        public string OccupationCityCountry { get; set; }
        public Nullable<int> CandidateId { get; set; }
    
        public virtual Canditate_Personal Canditate_Personal { get; set; }
    }
}
