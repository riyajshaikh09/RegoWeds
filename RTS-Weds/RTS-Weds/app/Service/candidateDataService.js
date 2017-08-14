(function () {
    "use strict";

    RTSWedsApp
        .factory("candidateDataService", ["$http", function ($http) {
           // var baseUrl = "http://localhost:38538/";
            var baseUrl = "http://rts-weds-services.azurewebsites.net";

            var getAllCandidateData = function (candidateId,candidateType) {

                var url = 'api/InfoHandle/getCandidateData?candidateId=' + candidateId + "&CandidateType=" + candidateType;

                return $http.get(baseUrl + url).then(function (response) {
                    return response.data;
                });
            };
         

            var addPersonalDetails = function (candidatePersonalData) {

                var url = 'api/InfoHandle/insertPersonalDetails';

                return $http.post(baseUrl + url, candidatePersonalData).then(function (response) {
                    return response.data;
                });
            };
        
            var addBirthDetails = function (birthData) {

                var url = 'api/InfoHandle/insertBirthdetails';

                return $http.post(baseUrl + url, birthData).then(function (response) {
                    return response.data;
                });
            };


            var addEducationDetails = function (eduData) {

                var url = 'api/InfoHandle/insertEducationDetails';

                return $http.post(baseUrl + url, eduData).then(function (response) {
                    return response.data;
                });
            };


            var addAddressDetails = function (addressData) {

                var url = 'api/InfoHandle/insertAddressDetails';

                return $http.post(baseUrl + url, addressData).then(function (response) {
                    return response.data;
                });
            };

            var addFamilyDetails = function (familydataData) {

                var url = 'api/InfoHandle/insertFamilyetails';

                return $http.post(baseUrl + url, familydataData).then(function (response) {
                    return response.data;
                });
            };

            var addExpectationDetails = function (expectationData) {

                var url = 'api/InfoHandle/insertExpectationdetails';

                return $http.post(baseUrl + url, expectationData).then(function (response) {
                    return response.data;
                });
            };

            var getSearchedData = function (searchCriteria) {

                var url = 'api/InfoHandle/getSearchedData';

                return $http.post(baseUrl + url, searchCriteria).then(function (response) {
                    return response.data;
                });
            };

            var sendEmailToContact = function (email) {

                var url = 'api/InfoHandle/sendEmailToContact';

                return $http.post(baseUrl + url, email).then(function (response) {
                    return response.data;
                });
            };

            
            return {

                getAllCandidateData: getAllCandidateData,
                addPersonalDetails: addPersonalDetails,
                addAddressDetails: addAddressDetails,
                addBirthDetails: addBirthDetails,
                addEducationDetails: addEducationDetails,
                addFamilyDetails: addFamilyDetails,
                addExpectationDetails: addExpectationDetails,
                getSearchedData: getSearchedData,
                sendEmailToContact: sendEmailToContact
               
            };
        }]);
}());

