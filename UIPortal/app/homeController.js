myApp.controller('homeController', function ($http, $location) {
    
    var vm = this;
    vm.test = '123';
    vm.customers = '';

    vm.callApiV1 = function () {
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

    vm.ChangeState = function () {
        alert("YOU CLIECKED state change");
        $location.path("/AddCustomer");
    }

    vm.Modify = function (index) {
        alert("YOU CLIECKED on Modify");
        $location.path("/ModifyCustomer/" + vm.customers[index].Id);
    }

    vm.Delete = function (index) {
        alert("YOU CLIECKED on delete");

        if (confirm("Are you sure you want to delete this record"))
        {
            var id  = (vm.customers[index].Id);
            $http({
                method: 'DELETE',
                url: 'http://localhost:6192/api/customers/' + id,
            }).then(function successCallback(response) {
                alert("Product Deleted Successfully !!!");
                vm.callApiV1();
            }, function errorCallback(response) {
                alert("Error : " + response.data.ExceptionMessage);
            });
        }
    }


   
});