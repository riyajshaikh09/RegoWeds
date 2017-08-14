RTSWedsApp.controller('candidateCtrl', function ($scope, $location, candidateDataService, $window, $rootScope) {
    $scope.message = 'candidateCtrl demo.';
    $scope.candidateType = "Male";
    $scope.candidateId = 0;
    var __init = function () {

        if ($location.path() === "/brides") {
            $scope.candidateType = "Female";
        } 

    }

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
        candidateDataService.getAllCandidateData($scope.candidateId, $scope.candidateType).then(onGetDataSucess, onGetDataFailure);

    }
    __init();
    __getCandidateData();
    
    
});