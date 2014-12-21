angular.module('mgApp').config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/Barrack', {
            templateUrl: '/app/view/barrack.html',
            controller: 'barrackController'
        })
        .otherwise({
            redirectTo: '/Barrack'
        });
}])