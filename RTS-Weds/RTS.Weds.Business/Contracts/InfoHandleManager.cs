using RTS.Weds.Business.Interface;
using RTS.Weds.Business.Model;
using RTS.Weds.Common;
using RTS.Weds.DataAcess.Dapper.Interface;
using RTS.Weds.DataAcess.Dapper.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;


namespace RTS.Weds.Business.Contracts
{
    public class InfoHandleManager : IInfoHandleManager 
    {
        ICandidateRepository _candidateRepository;
        IBirthDetailsRepository _birthDetailsRepository;
        IAddressDetailsRepository _addressDetailsRepository;
        IFamilyDetailsRepository _familyDetailsRepository;
        IEducationDetailsRepository _educationDetailsRepository;
        IExpectationsDetailsRepository _expectationsDetailsRepository;
        public InfoHandleManager(ICandidateRepository candidateRepository,
            IBirthDetailsRepository birthDetailsRepository,
            IAddressDetailsRepository addressDetailsRepository,
            IFamilyDetailsRepository familyDetailsRepository,
            IEducationDetailsRepository educationDetailsRepository,
            IExpectationsDetailsRepository expectationsDetailsRepository)
        {

            _candidateRepository = candidateRepository;
            _addressDetailsRepository = addressDetailsRepository;
            _birthDetailsRepository = birthDetailsRepository;
            _educationDetailsRepository = educationDetailsRepository;
            _familyDetailsRepository = familyDetailsRepository;
            _expectationsDetailsRepository = expectationsDetailsRepository;
        }
        public CandidateData getAllCandidateData(string candidateType)
        {

          var details= _candidateRepository.GetAll();

          List<Candidate> lstCandidates=  new List<Candidate>() {
               new Candidate { FirstName="Ganesh", MiddleName="Mahadev", LastName="Pawar", DateOfBorth="01/01/1990", Gender= "Male", BirthPlace="Satara" },
               new Candidate  { FirstName="Suresh", MiddleName="Mahadev", LastName="Pawar", DateOfBorth="01/01/1990", Gender= "Male", BirthPlace="Satara" },
                new Candidate  { FirstName="Saguna", MiddleName="Paresh", LastName="Salunkhe", DateOfBorth="01/01/1995", Gender= "Female", BirthPlace="Pune" }
                    };
            CandidateData allCandidates = new CandidateData();



            allCandidates.Candidates= lstCandidates.Where(o => o.Gender.Equals(candidateType)).ToList();
            return allCandidates;
        }

        public IEnumerable<object> getCandidateDetails(string candidateId)
        {
            throw new NotImplementedException();
        }

        public object registerCandidate()
        {
         return   _candidateRepository.registerCandidate();
            //throw new NotImplementedException();
        }


        public object insertCandidatePersonalDetails(Canditate_Personal personalData)
        {
            return _candidateRepository.insertCandidatePersonalDetails(personalData);
            //throw new NotImplementedException();
        }
        public IEnumerable<object> serachAllData(object searchCriteria)
        {
            
            throw new NotImplementedException();
        }

        public BirthDetails insertBirthdetails(BirthDetails data)
        {
            return _birthDetailsRepository.insertBirthDetails(data);
            
        }

        public AddressDetails insertAddressDetails(AddressDetails data)
        {
            return _addressDetailsRepository.insertAddressDetails(data);
        }

        public EducationDetails insertEducationDetails(EducationDetails data)
        {
           return _educationDetailsRepository.insertEducationDetails(data);
        }

        public FamilyDetails insertFamilyetails(FamilyDetails data)
        {
            return _familyDetailsRepository.insertFamilyDetails(data);
        }

        public ExpectationDetails insertExpectationdetails(ExpectationDetails data)
        {
            return _expectationsDetailsRepository.insertExpectationDetails(data);
        }

        public IEnumerable<CompleteCandidate> getCandidateData(int candidateId, string CandidateType)
        {
            return _candidateRepository.getCandidateData(candidateId, CandidateType);
            
        }

        public IEnumerable<CompleteCandidate> getSearchedData(SearchRequest searchCriteria)
        {
            return _candidateRepository.getSearchedData(searchCriteria);
        }
    }
}
