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
    
    public partial class Canditate_Personal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Canditate_Personal()
        {
            this.AddressDetails = new HashSet<AddressDetail>();
            this.BirthDetails = new HashSet<BirthDetail>();
            this.EducationDetails = new HashSet<EducationDetail>();
            this.ExpectationDetails = new HashSet<ExpectationDetail>();
            this.FamilyDetails = new HashSet<FamilyDetail>();
        }
    
        public int CandidateId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public string MaritialStatus { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string BloodGroup { get; set; }
        public string Complexion { get; set; }
        public string FoodHabits { get; set; }
        public string PhysicalDisability { get; set; }
        public string PhysicalDisabilityDetails { get; set; }
        public string specs { get; set; }
        public string lens { get; set; }
        public string CandidateDescription { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AddressDetail> AddressDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BirthDetail> BirthDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EducationDetail> EducationDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExpectationDetail> ExpectationDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FamilyDetail> FamilyDetails { get; set; }
    }
}