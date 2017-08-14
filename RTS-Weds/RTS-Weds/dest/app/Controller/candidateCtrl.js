RTSWedsApp.controller('candidateCtrl',  function ($scope, $location, candidateDataService) {
    $scope.message = 'candidateCtrl demo.';
    $scope.candidateType = "Male";

    var __init = function () {

        if ($location.path() == "/brides") {
            $scope.candidateType = "Female";
        } 

    }

    var onGetDataSucess = function (resp) {
        var data = resp;

        if (data != null && data.Candidates != null && data.Candidates.length > 0) {

            $scope.allCandidatesData = data.Candidates;
        }
    }
    var onGetDataFailure = function (resp) {
        var dat = resp;
    }
    __init();
    candidateDataService.getAllCandidateData($scope.candidateType).then(onGetDataSucess, onGetDataFailure);
});