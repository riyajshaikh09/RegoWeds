RTSWedsApp.controller('detailsCtrl', function ($scope, $routeParams, candidateDataService) {
    $scope.message = 'detailsCtrl demo.';
    $scope.candidateId = 0;
    $scope.candidateType = "";
    if (!angular.isUndefined($routeParams.candidateId))
    {
        $scope.candidateId = $routeParams.candidateId
    }



    var onGetDataSucess = function (resp) {
        var data = resp;

        if (data != null && data.length > 0)
        {
            $scope.allCandidatesData = data[0];
        }
    }
    var onGetDataFailure = function (resp) {
        var dat = resp;
    }


    candidateDataService.getAllCandidateData($scope.candidateId, $scope.candidateType).then(onGetDataSucess, onGetDataFailure);
});