// create the module and name it RTSWeds
var RTSWedsApp = angular.module('RTSWeds', ['ngRoute']);

// configure our routes
RTSWedsApp.config(function ($routeProvider, $locationProvider) {
    $locationProvider.html5Mode(false);
    $locationProvider.hashPrefix('');

    $routeProvider

        // route for the home page
        .when('/', {
            templateUrl: 'app/template/home.html',
            controller: 'mainController'
        })

        // route for the about page
        .when('/about', {
            templateUrl: 'app/template/about.html',
            controller: 'aboutCtrl'
        })
        .when('/search', {
            templateUrl: 'app/template/search.html',
            controller: 'searchCtrl'
        })
        .when('/brides', {
            templateUrl: 'app/template/grooms.html',
            controller: 'candidateCtrl'
        })
        .when('/grooms', {
            templateUrl: 'app/template/grooms.html',
            controller: 'candidateCtrl'
        })

        // route for the contact page
        .when('/contact', {
            templateUrl: 'app/template/contact.html',
            controller: 'contactCtrl'
        });
});

// create the controller and inject Angular's $scope
RTSWedsApp.controller('mainController', function ($scope) {
    // create a message to display in our view
    $scope.currentNavItem = 'page1';
    $scope.message = 'Everyone come and see how good I look!';
});

