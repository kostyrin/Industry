erpApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/customers', {
                templateUrl: '/scripts/app/partials/customers.html',
                controller: 'customersCtrl'
            })
        .when('/customer/edit/:id',
            {
                templateUrl: '/scripts/app/partials/customerEdit.html',
                controller: 'customerEditCtrl'
            })
        .otherwise(
            {
                redirectTo: '/'
            });
}]);