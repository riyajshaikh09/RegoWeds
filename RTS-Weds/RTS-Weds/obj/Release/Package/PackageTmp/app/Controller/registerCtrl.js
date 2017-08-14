RTSWedsApp.controller('registerCtrl', function ($scope,$rootScope, candidateDataService, $mdToast) {
    var _init = function () {

        $scope.message = 'Register Here!';
        $scope.isUserImageAvailable = false;
        $scope.disableAddButton = true;
        $rootScope.hideToast = true;
        $scope.user = {

        };

        $scope.expectations = {
            CandidateId:  $scope.user.CandidateId
        };
        $scope.birthDetails = {
            CandidateId: $scope.user.CandidateId
        };
        $scope.eduDetails = {
            CandidateId: $scope.user.CandidateId
        };
        $scope.familyDetails = {
            CandidateId: $scope.user.CandidateId
        };
        $scope.addressDetails = {
            CandidateId: $scope.user.CandidateId
        };
        $scope.example = {
            value: new Date()
        };
        $scope.states = ('AL AK AZ AR CA CO CT DE FL GA HI ID IL IN IA KS KY LA ME MD MA MI MN MS ' +
        'MO MT NE NV NH NJ NM NY NC ND OH OK OR PA RI SC SD TN TX UT VT VA WA WV WI ' +
        'WY').split(' ').map(function (state) {
            return { abbrev: state };
        });


        $scope.genders = ['Male', 'Female'];

        $scope.maritialStatus = ['Unmarried', 'Divorcee', 'Widow'];
        $scope.bloodGroupList = ['A+', 'O+', 'B+', 'AB+', 'A-', 'O-', 'B-', 'AB-'];
        $scope.skinComplexions = ['Light', 'Fair', 'Medium', 'Olive', 'Brown', 'Black'];
        $scope.foodHabits = ['Vegitarian', 'Non-Vegitarian', 'Both[Veg-NonVeg]'];
        $scope.choices = ['Yes', 'No'];
        $scope.qualificationTypes = ['SSC', 'HSC', 'Deploma', 'Graduation', 'Post Graduation', 'Medical'];


        $scope.last = {
            bottom: false,
            top: true,
            left: false,
            right: true
        };
        $scope.toastPosition = angular.extend({}, $scope.last);

    }


    $scope.registerCandidate = function () {

        var candidateData = $scope.user;

        candidateDataService.addPersonalDetails(candidateData).then(onGetDataSucess, onGetDataFailure);
    }

    $scope.checkCandidateid = function () {
        var candidateAvailable = true;
        if (!angular.isUndefined($scope.user.CandidateId) && $scope.user.CandidateId !== "")
        {
            candidateAvailable = false;
        }
        return candidateAvailable;
    }


    $scope.addBirthDetails = function ()
    {
        $scope.birthDetails.CandidateId= $scope.user.CandidateId;
        candidateDataService.addBirthDetails($scope.birthDetails).then(onGetDataSucess, onGetDataFailure);
    }
    

    $scope.addAddressDetails = function () {
        $scope.addressDetails.CandidateId = $scope.user.CandidateId;
        candidateDataService.addAddressDetails($scope.addressDetails).then(onGetDataSucess, onGetDataFailure);
    }

    $scope.addEducationDetails = function () {
        $scope.eduDetails.CandidateId = $scope.user.CandidateId;
        candidateDataService.addEducationDetails($scope.eduDetails).then(onGetDataSucess, onGetDataFailure);
    }


    $scope.addExpectationDetails = function () {
        $scope.expectations.CandidateId = $scope.user.CandidateId;
        candidateDataService.addExpectationDetails($scope.expectations).then(onGetDataSucess, onGetDataFailure);
    }

    $scope.addFamilyDetails = function () {
        $scope.familyDetails.CandidateId = $scope.user.CandidateId;
        candidateDataService.addFamilyDetails($scope.familyDetails).then(onGetDataSucess, onGetDataFailure);
    }

    var onGetDataSucess = function (resp) {
        var data = resp;

        if (data !== null) {
            $scope.showSimpleToast("Information Added Sucessfully.");
            $scope.user.CandidateId = data.CandidateId;

            if (!angular.isUndefined(data.ImageData))
            {
                $scope.user.ImageData = data.ImageData;
                $scope.isUserImageAvailable = true;
             }
            $scope.disableAddButton = false;
        }
    }
    var onGetDataFailure = function (resp) {
        var dat = resp;
    }
 

    $scope.getToastPosition = function () {
        sanitizePosition();

        return Object.keys($scope.toastPosition)
          .filter(function (pos) { return $scope.toastPosition[pos] })
          .join(' ');
    };

    var sanitizePosition=  function () {
        var current = $scope.toastPosition;

        if (current.bottom && $scope.last.top) current.top = false;
        if (current.top && $scope.last.bottom) current.bottom = false;
        if (current.right && $scope.last.left) current.left = false;
        if (current.left && $scope.last.right) current.right = false;

        $scope.last = angular.extend({}, current);
    }

    $scope.showSimpleToast = function (message) {
       
        var pinTo = $scope.getToastPosition();
        var el = angular.element(document.getElementById("messageCenterdiv"));
        $mdToast.show(
          $mdToast.simple()
            .textContent(message)
            .position("top right")
            .hideDelay(3000)
            .parent(el)
        )
    };

    _init();    

});


  


