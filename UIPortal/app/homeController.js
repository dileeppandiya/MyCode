myApp.controller('homeController', function ($http) {
    
    var vm = this;
    vm.test = '123';
    vm.customers = '';

    vm.callApiV1 = function () {
        alert("YOU CLIECKED ON VER 1.0 API");
        $http.get("http://localhost:6192/api/customers")
        .then(function (response) {
            vm.customers = response.data;
            
        });
    }

    vm.callApiV2 = function () {
        alert("YOU CLIECKED ON VER 1.0 API");
        $http.get("http://localhost:6192/api/customers")
        .then(function (response) {
            vm.customers = response.data;
        });

    }

   
});