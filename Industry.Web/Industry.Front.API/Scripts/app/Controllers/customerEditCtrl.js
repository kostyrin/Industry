'use strict';

erpApp.controller('customerEditCtrl',
    function ($scope, $routeParams, $location, customerDataSource) {
        var customerId = $routeParams.id;

        $http.get('/api/Customer/' + customerId).success(function(data) {
                $scope.customer = data;
                $scope.loading = false;
            })
            .error(function() {
                $scope.error = "An Error has occured while loading posts!";
                $scope.loading = false;
            });
        //customerDataSource.filter({ field: "CustomerID", operator: "eq", value: customerId });
        //$scope.customer = customerDataSource.at(0);

        //$scope.save = function () {
        //    customerDataSource.view()[0].dirty = true;
        //    customerDataSource.sync();
        //    $location.url('/customer');
        //};

        //$scope.cancel = function () {
        //    $location.url('/customer');
        //}
    });