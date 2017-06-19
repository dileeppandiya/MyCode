myApp.controller('AddCustomerCtrl', function ($http, $location) {
    
    var customer = this;

    customer.user = {
        FirstName: 'Dileep',
        LastName: 'Pandiya',
        id : '2',
    };


    customer.AddCustomer = function (){
            $http({
                method: 'POST',
                url: 'http://localhost:6192/api/customers',
                data: customer.user
            }).then(function successCallback(response) {
                alert("Product Added Successfully !!!");
                $location.path("/");
            }, function errorCallback(response) {
                alert("Error : " + response.data.ExceptionMessage);
            });
    };


    customer.UpdateCustomer = function () {
        $http({
            method: 'PUT',
            url: 'http://localhost:6192/api/customers',
            data: customer.user
        }).then(function successCallback(response) {
            alert("Product Added Successfully !!!");
        }, function errorCallback(response) {
            alert("Error : " + response.data.ExceptionMessage);
        });
    };

       
    customer.DeleteCustomer = function () {
        $http({
            method: 'DELETE',
            url: 'http://localhost:6192/api/customers/1',
        }).then(function successCallback(response) {
            alert("Product Deleted Successfully !!!");
        }, function errorCallback(response) {
            alert("Error : " + response.data.ExceptionMessage);
        });
    };


    }
);

myApp.controller('ModifyCustomerController', function ($http, $location, $routeParams) {

    var param1 = $routeParams.id;
    var customer = this;


    alert(param1);

    $http.get("http://localhost:6192/api/customers/" + param1)
       .then(function (response) {
           customer.user = response.data;
           alert(JSON.stringify(customer.user));
       });

    var data = { id: param1, FirstName: 'Dileep', LastName: '1' };

    

    customer.UpdateCustomer = function () {
        alert(customer.user.LastName);
        $http({
            method: 'PUT',
            url: 'http://localhost:6192/api/customers',
            data: data
        }).then(function successCallback(response) {
            alert("Product modified Successfully !!!");
        }, function errorCallback(response) {
            alert("Error : " + response.data.ExceptionMessage);
        });
    };

}
);