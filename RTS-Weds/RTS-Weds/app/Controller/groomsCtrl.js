RTSWedsApp.controller('groomsCtrl', ["$scope", "candidateDataService", function ($scope, candidateDataService) {
    $scope.message = 'groomsCtrl demo.';

    var onGetDataSucess = function (resp) {
        var data = resp;

        if (data != null && data.Candidates != null && data.Candidates.length > 0) {

            $scope.allCandidatesData = data.Candidates;
        }
    }
    var onGetDataFailure = function (resp) {
        var dat = resp;
    }
    candidateDataService.getAllCandidateData("Male").then(onGetDataSucess, onGetDataFailure);
}]);