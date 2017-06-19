// create the module and name it myApp
var myApp = angular.module('myApp', ['ngRoute']);

// configure our routes
myApp.config(function ($routeProvider, $httpProvider) {
    $routeProvider

        .when('/', {
            templateUrl: 'pages/home.html',
            controller: 'homeController'
        })

        .when('/about', {
            templateUrl: 'pages/about.html',
            controller: 'homeController'
        })

        .when('/contact', {
            templateUrl: 'pages/contact.html',
            controller: 'contactController'
        })

        .when('/AddCustomer', {
            templateUrl: 'pages/AddCustomer.html',
            controller: 'AddCustomerCtrl'
        })

        .when('/ModifyCustomer/:id', {
             templateUrl: 'pages/ModifyCustomer.html',
             controller: 'ModifyCustomerController'
         })

    ;

    $httpProvider.defaults.headers.common['Access-Control-Allow-Origin'] = '*';
});

// create the controller and inject Angular's $scope

myApp.controller('contactController', function ($scope) {
    $scope.message = 'Contact us! This is just a demo application';
});

