RTSWedsApp.controller('contactCtrl', function ($scope, candidateDataService) {
        $scope.message = 'Contact us!';

        $scope.email = {};
        $scope.sucessMessage = "";
        var onGetDataSucess = function (resp) {
            var data = resp;
            $scope.email = {};

            $scope.sucessMessage ="Thanks For contact well get back you soon."
            if (data != null && data.length > 0) {
              //  $scope.allCandidatesData = data[0];
            }
        }
        var onGetDataFailure = function (resp) {
         //   var dat = resp;
        }


       
        $scope.sendEmail = function () {

            candidateDataService.sendEmailToContact($scope.email).then(onGetDataSucess, onGetDataFailure);
        }
    });


