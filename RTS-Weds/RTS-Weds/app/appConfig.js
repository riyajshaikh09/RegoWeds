// create the module and name it RTSWeds
var RTSWedsApp = angular.module('RTSWeds', ['ngRoute', 'ngMaterial', 'ngAnimate']);
// configure our routes
RTSWedsApp.config(function ($routeProvider, $locationProvider) {
    $routeProvider
         // route for the home page
        .when('/', {
            templateUrl: 'app/template/home.html',
            controller: 'mainController'
        })

        // route for the about page
        .when('/about', {
            templateUrl: 'app/template/about.html',
            controller: 'aboutCtrl',
            controllerAs: 'vm',
        })
         .when('/register', {
             templateUrl: 'app/template/register.html',
             controller: 'registerCtrl',
            
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
        .when('/details', {
            templateUrl: 'app/template/details.html',
            controller: 'detailsCtrl'
        })
        // route for the contact page
        .when('/contact', {
            templateUrl: 'app/template/contact.html',
            controller: 'contactCtrl'
        });

    $locationProvider.hashPrefix('');
});
// create the controller and inject Angular's $scope
RTSWedsApp.controller('mainController', function ($scope,$rootScope) {
    // create a message to display in our view
    $rootScope.enableLoadingImage = false;

    $scope.currentNavItem = 'page1';
    $scope.message = 'Everyone come and see how good I look!';

    $(document).ready(function () {
        $("nav").find("li").on("click", "a", function () {
            $('.navbar-collapse.in').collapse('hide');
        });
    });
});
