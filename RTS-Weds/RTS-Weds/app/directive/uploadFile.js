

RTSWedsApp.directive('uploadFile', uploadFile);

function uploadFile() {
    var directive = {
        restrict: 'E',
        template: '<input id="fileInput" type="file" class="ng-hide"> <label id="uploadButton"class="md-button md-raised md-primary" style="width:95%" aria-label="attach_file">Add Photo</label> <input class="ng-hide" id="textInput" ng-model="fileName" type="text" placeholder="No file chosen" ng-readonly="true">',
        link: apsUploadFileLink
    };
    return directive;
}

function apsUploadFileLink(scope, element, attrs) {
    var input = angular.element(document.getElementById('fileInput'));
    var button = angular.element(document.getElementById('uploadButton'));
    var textInput = angular.element(document.getElementById('textInput'));

    if (input.length && button.length && textInput.length) {
        button.bind('click', function () {
            input[0].click();
        });
        textInput.bind('click', function () {
            input[0].click();
        });
    }

    input.on('change', function (e) {
        var files = e.target.files;
        if (files[0]) {
            scope.fileName = files[0].name;
            scope.$parent.user.userImage = files[0].name;

            scope.formdata = new FormData();
            scope.formdata.append('file', files[0].name);

            var filesSelected = files;
            if (filesSelected.length > 0) {
                var fileToLoad = filesSelected[0];

                var fileReader = new FileReader();

                fileReader.onload = function (fileLoadedEvent) {
                    var srcData = fileLoadedEvent.target.result; // <--- data: base64
                    scope.$parent.user.ImageData = srcData;
                    scope.$parent.isUserImageAvailable = true;
                    var newImage = document.createElement('img');
                    newImage.src = srcData;
                    scope.$apply();
                }
                fileReader.readAsDataURL(fileToLoad);

            }

        } else {
            scope.fileName = null;
        }
        scope.$apply();
    });
}