RTSWedsApp.controller('searchCtrl', function ($scope, $rootScope, candidateDataService, $window) {
    $scope.message = 'searchCtrl demo.';
    $scope.searchCriteria = {};
    $scope.genders = ['Male', 'Female'];

    $scope.maritialStatus = ['Unmarried', 'Divorcee', 'Widow'];

    var onGetDataSucess = function (resp) {
        var data = resp;
        $rootScope.enableLoadingImage = false;

        if (data != null && data.length > 0) {

            $scope.allCandidatesData = data;
        }
    }
    var onGetDataFailure = function (resp) {
        $rootScope.enableLoadingImage = false;
        var dat = resp;
    }

    $scope.navigateToDetails = function (candidate) {

        $window.open('#/details?candidateId=' + candidate.CandidateId);
    }

    var __getCandidateData = function () {
        $rootScope.enableLoadingImage = true;
        candidateDataService.getSearchedData($scope.searchCriteria).then(onGetDataSucess, onGetDataFailure);

    }

    $scope.searchCandidates = function () {
        $scope.allCandidatesData = [];
        __getCandidateData();
    }

    $scope.clearCriteria = function () {
        $scope.searchCriteria = {};
        $scope.allCandidatesData = [];

    }
   
});