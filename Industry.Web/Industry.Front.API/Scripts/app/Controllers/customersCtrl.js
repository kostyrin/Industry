erpApp.controller('customersCtrl', ['$scope', '$http', function ($scope, $http) {
    //$scope.customers = customersService.query();

    //get all customer information
    $http.get('/api/Customer/').success(function (data) {
        $scope.customers = data;
        $scope.loading = false;
    })
    .error(function () {
        $scope.error = "An Error has occured while loading posts!";
        $scope.loading = false;
    });

    //by pressing toggleEdit button ng-click in html, this method will be hit
    $scope.toggleEdit = function () {
        //this.customer.editMode = !this.customer.editMode;
    };

    //Edit Customer
    $scope.save = function () {
        $scope.loading = true;
        var frien = this.customer;
        $http.put('/api/Customer/' + frien.CustomerId, frien).success(function (data) {
            alert("Saved Successfully!!");
            frien.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            alert("Error");
            $scope.error = "An Error has occured while Saving customer! " + data;
            $scope.loading = false;
        });
    };

}]);