// create the module and name it myApp
var myApp = angular.module('myApp', ['ngRoute', 'ngMaterial', 'ngMessages']);

// configure our routes
myApp.config(function ($routeProvider, $httpProvider) {
    $routeProvider

        // route for the home page
        .when('/', {
            templateUrl: 'pages/home.html',
            controller: 'homeController'
        })

        // route for the about page
        .when('/about', {
            templateUrl: 'pages/about.html',
            controller: 'customerController'
        })

        // route for the contact page
        .when('/contact', {
            templateUrl: 'pages/contact.html',
            controller: 'contactController'
        })

        // route for the contact page
        .when('/AddCustomer', {
            templateUrl: 'pages/AddCustomer.html',
            controller: 'AddCustomerCtrl'
        })
    ;

    $httpProvider.defaults.headers.common['Access-Control-Allow-Origin'] = '*';
});

// create the controller and inject Angular's $scope

myApp.controller('contactController', function ($scope) {
    $scope.message = 'Contact us! This is just a demo application';
});

myApp.controller('AddCustomerCtrl', function ($scope) {
    $scope.user = {
        name: 'John Doe',
        email: '',
        phone: '',
        address: 'Mountain View, CA',
        donation: 19.99
    };
});